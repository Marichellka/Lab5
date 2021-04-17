﻿using System.Collections.Generic;
using System.Collections;
using System;

namespace Project
{
    public class Optimisation
    {
        private Tree Head;
        public Hashtable ht { get; private set; }
        public Optimisation(Tree item)
        {
            Head = item;
            ht = new Hashtable();
        }
        public void BFS(int n = 0)
        {
            bool[] used = new bool[20];
            used[n] = true;
            Queue<Tree> queue = new Queue<Tree>();
            queue.Enqueue(Head);
            while (queue.Count != 0)
            {
                Tree item = queue.Dequeue();
                if (item.Key.Contains("="))
                {
                    if (!item.Childs[1].Key.Equals("+") || !item.Childs[1].Key.Equals("-") || !item.Childs[1].Key.Equals("*") || !item.Childs[1].Key.Equals("/"))
                    {
                        ht.Add(item.Childs[0].Key, item.Childs[1].Key);
                    }
                }
                for (int i = 0; i < item.Childs.Count; i++)
                {
                    if (item.Childs[i] != null && !used[n + i + 1])
                    {
                        used[n + i + 1] = true;
                        queue.Enqueue(item.Childs[i]);
                        n += i + 1;
                    }
                }
            }
        }
    }
}
