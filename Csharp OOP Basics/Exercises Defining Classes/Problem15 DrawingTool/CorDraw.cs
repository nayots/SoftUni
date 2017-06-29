using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem15_DrawingTool
{
    public class CorDraw
    {
        private Square figure;

        public CorDraw(Square figure)
        {
            this.Figure = figure;
        }

        public Square Figure
        {
            get { return figure; }
            set { figure = value; }
        }
    }
}