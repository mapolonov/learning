using System;
using System.Collections.Generic;
using System.Linq;

namespace MatrixSequenceFind
{
    class Tree
    {
        public P point;
        public int level;
        public int parent;
    }

    struct P
    {
        public int x;
        public int y;
    }

    class Program
    {
        
        private static int[,] matrix = new int[7, 7]
            {
                {1, 1, 1, 1, 1, 1, 1},
                {8, 7, 6, 1, 1, 1, 1},
                {1, 1, 5, 4, 3, 2, 1},
                {1, 1, 1, 3, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1}
            };

        private static List<Tree> listTree = new List<Tree>();

        static void Main(string[] args)
        {
            
            var startP = new P() {x = 2, y = 3};
            listTree.Add(new Tree(){level = 0, parent = 0, point = startP});
            findDown(startP, 0);

            Tree res = listTree.OrderByDescending(t => t.level).First();
            outputCoordinates(res);
        }

        private static void outputCoordinates(Tree t)
        {
            if (t.level == 0 && t.parent == 0)
            {
                Console.WriteLine("[{0},{1}] = {2}", t.point.x, t.point.y, matrix[t.point.x, t.point.y]);
                return;
            }

            Console.WriteLine("[{0},{1}] = {2}", t.point.x, t.point.y, matrix[t.point.x, t.point.y]);
            var item = listTree.Find(p => p.level == t.parent);
            outputCoordinates(item);
        }

        private static void findDown(P p, int level)
        {
            if (p.x < 6 && (matrix[p.x, p.y] - matrix[p.x + 1, p.y] == 1))
            {
                var pNext = new P() {x = p.x + 1, y = p.y};
                listTree.Add(new Tree() { level = level + 1, parent = level, point = pNext });
                findDown(pNext, level + 1);
            }

            if (p.y < 6 && (matrix[p.x, p.y] - matrix[p.x, p.y + 1] == 1))
            {
                var pNext = new P() { x = p.x, y = p.y + 1 };
                listTree.Add(new Tree() { level = level + 2, parent = level, point = pNext });
                findDown(pNext, level + 2);
            }
        }

    }
}
