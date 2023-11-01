using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimplePuzzle
{
    class PuzzlePiece
    {
        public int index = -1;

        public ImageSource PuzzleImageSource { get; set; }

        public string UriString { get; set; }

        public Type DragFrom { get; set; }
    }
}
