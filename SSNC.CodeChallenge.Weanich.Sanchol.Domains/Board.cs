﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSNC.CodeChallenge.Weanich.Sanchol.Domains
{
    public class Board
    {
        public Board(int width, int height)
        {
            Width = width; 
            Height = height;
        }
        public int Width { get; set; }
        public int Height { get; set; }
        
    }
}
