using System;

namespace Lsj.Util.Collections
{
    /// <summary>
    /// Weighted Digraph
    /// </summary>
    public class WeightedSimpleDigraph
    {
        private readonly int?[,] data;

        /// <summary>
        /// Order
        /// </summary>
        public int Order { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Collections.WeightedSimpleDigraph"/> class.
        /// </summary>
        /// <param name="order"></param>
        public WeightedSimpleDigraph(int order)
        {
            this.Order = order;
            this.data = new int?[order, order];
        }

        /// <summary>
        /// Add Edge
        /// </summary>
        /// <param name="from">From Vertex</param>
        /// <param name="to">To Vertex</param>
        /// <param name="weight">Weight</param>
        public void AddEdge(int from, int to, int weight)
        {
            if (from >= Order || to >= Order)
            {
                throw new ArgumentOutOfRangeException("From or To cannot larger than order");
            }
            if (data[from, to] != null)
            {
                throw new ArgumentException("there is already a edge");
            }
            data[from, to] = weight;
        }

        /// <summary>
        /// Get Optimal Path with Dijkstra Algotithm
        /// </summary>
        /// <param name="from">From Vertex</param>
        /// <param name="dis">Distances</param>
        /// <param name="prv">Previous Vertices</param>
        public void OptimalPathWithDijkstra(int from, out int?[] dis, out int?[] prv)
        {
            if (from >= Order)
            {
                throw new ArgumentOutOfRangeException("From cannot larger than order");
            }
            dis = new int?[Order];
            prv = new int?[Order];
            var flag = new bool[Order];
            for (int i = 0; i < Order; i++)
            {
                dis[i] = data[from, i];
                if (dis[i] != null)
                {
                    prv[i] = from;
                }
            }
            dis[from] = 0;
            flag[from] = true;
            prv[from] = from;
            for (int i = 0; i < Order; i++)
            {
                var nearest = from;
                var minDis = (int?)null;
                for (int j = 0; j < Order; j++)
                {
                    if (!flag[j] && dis[j] != null && (minDis == null || dis[j].Value < minDis.Value))
                    {
                        minDis = dis[j];
                        nearest = j;
                    }
                }
                if (minDis == null)
                {
                    return;
                }
                else
                {
                    flag[nearest] = true;
                    for (int k = 0; k < Order; k++)
                    {
                        if (!flag[k] && data[nearest, k] != null && (dis[k] == null || minDis.Value + data[nearest, k] < dis[k]))
                        {
                            dis[k] = minDis.Value + data[nearest, k];
                            prv[k] = nearest;
                        }
                    }
                }
            }
        }
    }
}
