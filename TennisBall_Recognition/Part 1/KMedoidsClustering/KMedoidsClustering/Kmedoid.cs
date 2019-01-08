using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMedoidsClustering
{
    [Serializable]
    public class KMedoid<T> where T : new()
    {
        private readonly Func<T, T, double> _distanceFunc; // delegate
        private double[,] _distances; // distance matrix
        public int[] _medoids; // medoid indexes
        /// <summary>
        /// After calling Compute(), this List contains an integer for each
        /// input element, representing which cluster it belongs to.
        /// </summary>
        public List<int> Clusters { get; set; }

        public KMedoid(Func<T, T, double> distanceFunc)
        {
            _distanceFunc = distanceFunc;
        }

        /// <summary>
        /// Assign cluster labels to the provided inputs.
        /// </summary>
        /// <param name="k">The number of clusters.</param>
        /// <param name="inputs">The inputs.</param>
        /// </summary>
        public void Compute(int k, List<T> inputs)
        {
            Clusters = new List<int>();
            //calculate distance matrix
            _distances = new double[inputs.Count, inputs.Count];
            for (int i = 0; i < inputs.Count - 1; i++)
            {
                for (int j = i + 1; j < inputs.Count; j++)
                {
                    _distances[i, j] = _distanceFunc(inputs[i], inputs[j]);
                    _distances[j, i] = _distances[i, j];
                }
            }
            _medoids = Enumerable.Range(1, k).Select(x => -1).ToArray();
            //initialization
            InitializeMedoids(inputs, k);
            //loop until no further improvement is made
            bool changed = true;
            double lastTotalCost = TotalCost(_medoids, inputs);
            int countIterations = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (changed)
            {
                //for each medoid, we try replacing it with a nonmedoid
                //if the total score improves, we keep the change
                _medoids = GetNewMedoids(k, ref inputs, ref lastTotalCost, out changed);
                Console.WriteLine("total cost = " + lastTotalCost.ToString() + "iter=" + countIterations.ToString());
                countIterations++;
                if ((sw.ElapsedMilliseconds > 300000) || (changed == false))
                    break;
            }
            // get the clusters from the current medoids
            UpdateClusters(inputs);
        }

        /// <summary>
        /// A deterministic approach to initialization.
        /// Follows Park et al (http://citeseerx.ist.psu.edu/viewdoc/download?doi=10.1.1.90.7981&rep=rep1&type=pdf) for the first medoid.
        /// /// Then picks medoids on the basis of maximum difference from the already existing ones.
        /// /// </summary>
        private void InitializeMedoids(List<T> inputs, int k)
        {
            double[] distanceSums = new double[inputs.Count];
            double[,] p = new double[inputs.Count, inputs.Count];
            double[] pSum = new double[inputs.Count];
            for (int i = 0; i < inputs.Count; i++)
            {
                for (int j = 0; j < inputs.Count; j++)
                {
                    distanceSums[i] += _distances[i, j];
                }
            }
            for (int i = 0; i < inputs.Count; i++)
            {
                for (int j = 0; j < inputs.Count; j++)
                {
                    p[i, j] += _distances[i, j] / distanceSums[i];
                }
            }
            for (int i = 0; i < inputs.Count; i++)
            {
                for (int j = 0; j < inputs.Count; j++)
                {
                    pSum[i] += p[j, i];
                }
            }

            _medoids[0] = Array.IndexOf(pSum, pSum.Min());
            //we have the first medoid, now simply select new ones on the basis of maximum distance from the existing ones
            for (int i = 1; i < k; i++)
            {
                double[] medoidDistanceSums = new double[inputs.Count];
                for (int j = 0; j < i; j++)
                {
                    for (int l = 0; l < inputs.Count; l++)
                    {
                        medoidDistanceSums[l] += _distances[l, _medoids[j]];
                        
                    }
                }
                if (_medoids.Contains(Array.IndexOf(medoidDistanceSums, medoidDistanceSums.Max())) == true)
                {
                    int q = 0;
                    while (q >= 0)
                    {
                        double po = Array.IndexOf(medoidDistanceSums, medoidDistanceSums.OrderByDescending(a => a).Distinct().Skip(q).First());
                        if (_medoids.Contains(Array.IndexOf(medoidDistanceSums, medoidDistanceSums.OrderByDescending(a => a).Distinct().Skip(q).First())) == false)
                        {
                            _medoids[i] = Array.IndexOf(medoidDistanceSums, medoidDistanceSums.OrderByDescending(a => a).Distinct().Skip(q).First());
                            q = -5;
                        }
                        q++;
                    }
                }
                else
                {
                    _medoids[i] = Array.IndexOf(medoidDistanceSums, medoidDistanceSums.Max());
                }
            }

        }

        /// <summary>
        /// Sets the cluster label for each input, depending on which medoid it is closest to.
        /// </summary>
        private void UpdateClusters(List<T> inputs)
        {
            for (int i = 0; i < inputs.Count; i++)
            {
                var medoidDistances = _medoids.Select(x => _distances[x, i]).ToList();
                int minIndex = 0;
                double minDistance = double.MaxValue;
                for (int j = 0; j < medoidDistances.Count; j++)
                {
                    if (medoidDistances[j] < minDistance)
                    {
                        minDistance = medoidDistances[j];
                        minIndex = j;
                    }
                }
                Clusters.Add(minIndex);
            }
        }

        /// <summary>
        /// Creates a new set of medoids by trying to replace current medoids with nonmedoid points.
        /// </summary>
        private int[] GetNewMedoids(int k, ref List<T> inputs, ref double lastTotalCost, out bool changed)
        {
            //--------serial version--------------------------------
            var newMedoids = new int[k];
            for (int i = 0; i < _medoids.Length; i++)
            {
                newMedoids[i] = _medoids[i];
            }
            for (int i = 0; i < k; i++)
            {
                var nonMedoids = Enumerable.Range(0, inputs.Count).Where(x => !_medoids.Contains(x)).ToList();
                foreach (int t in nonMedoids)
                {
                    newMedoids[i] = t;
                    var cost = TotalCost(newMedoids, inputs);
                    if (cost < lastTotalCost)
                    {
                        changed = true;
                        lastTotalCost = cost;
                        return newMedoids;
                    }
                }
                newMedoids[i] = _medoids[i];
            }
            changed = false;
            return _medoids;
            //--------------------------------------------------------
        }

        /// <summary>
        /// Calculates the total cost given a set of points and medoids.
        /// Total cost is the sum of the minimum distances between each point and a medoid.
        /// </summary>
        private double TotalCost(int[] medoids, List<T> inputs)
        {
            double totalCost = 0;
            for (int i = 0; i < inputs.Count; i++)
            {
                if (!medoids.Contains(i))
                {
                    totalCost += medoids.Select(x => _distances[x, i]).Min();
                }
            }
            return totalCost;
        }
    }
}