using System;
using System.Collections;
using System.Collections.ObjectModel;
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
using System.Windows.Threading;
using System.Threading;

namespace SimplePuzzle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void RoundedButton_Click(object sender, RoutedEventArgs e)
        {
            // Sluit de applicatie
            Application.Current.Shutdown();
        }

        /*
         * Ok. These steps will be the scenario for this puzzle application.
         * 1. Application started, MainWindow created, initialize all the puzzle piece.
         * 3. Player will drag a puzzle piece and drop it to the one of the image of the placement area or
         *    he may switch between puzzle piece on the image on placement area. 
         * 3. Foreach he do dropping / switching puzzle piece, check if it is correct.
         * 4. If correct, he win.
         */

        /*
         * It will be the domain modelling for the application.
         * 1. In the application there are puzzle which consist of nine puzzle piece.
         * 2. Puzzle have name. Puzzle could be edited. If it has been edited, an event edited raised, then 
         *    the puzzle will be validated.
         * 3. puzzle piece has image and index, number to identify item and determine where it must be drop.
         * 4. Placement area has 9 placement item which each has index to identify them and to show if a puzzle piece 
         *    has been dropped correctly and the puzzle index to identify which puzzle piece is dropped there.
         */

        #region Objects

        Puzzle puzzle = new Puzzle();

        ObservableCollection<PuzzlePiece> itemPlacement = new ObservableCollection<PuzzlePiece>();

        PuzzlePiece emptyItem = new PuzzlePiece();

        ListBox lbDragSource;

        Canvas cvDragSource;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor bro :D
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();


            //Initialize puzzle
            puzzle.Initialize(1);

            //Initialize Placement item
            emptyItem.index = -1;

            emptyItem.PuzzleImageSource = new BitmapImage();

            emptyItem.UriString = "";

            for (int i = 0; i < 9; i++)
            {
                itemPlacement.Add(emptyItem);

                //index is used to determine the item placement index and 
                //the value is the same as array index
                itemPlacement[i].index = i;
            }

            //Display puzzle piece in listbox
            puzzleItemList.ItemsSource = puzzle.puzzlePiece;

            //puzzle edited handler
            puzzle.Edited += new EventHandler(puzzle_Edited);
        }

        #endregion

        #region Dragging handler

        /// <summary>
        /// Dragging handler if the drag from the listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void puzzleItemList_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListBox parent = sender as ListBox;

            lbDragSource = parent;

            object data = GetObjectDataFromPoint(lbDragSource, e.GetPosition(parent));

            if (data != null)
            {
                PuzzlePiece itemSelected = data as PuzzlePiece;

                itemSelected.DragFrom = typeof(ListBox);

                DragDrop.DoDragDrop(lbDragSource, data, DragDropEffects.Move);
            }
        }

        /// <summary>
        /// This method handle when user drag puzzle 
        /// item from the canvas. Something to underline, the data transferred must
        /// be the puzzle piece directly from puzzle object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PzItmCvs_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Get the canvas associated and the puzzle piece
            Canvas parent = sender as Canvas;

            cvDragSource = parent;

            object data = GetDataFromCanvas(cvDragSource);

            if (data != null)
            {
                PuzzlePiece itemSelected = data as PuzzlePiece;

                itemSelected.DragFrom = typeof(Canvas);

                DragDrop.DoDragDrop(cvDragSource, data, DragDropEffects.Move);
            }
        }

        #endregion

        #region Drop handler

        private void PuzzleItemDrop(object sender, DragEventArgs e)
        {
            /*
             * To drop item, follow these steps.
             * 1. Get the item dropped and put it to the appropriate canvas. 
             *    a. If the canvas is empty, and the item dragged is from listbox, then do that way. 
             *    b. If the canvas is empty and the item dragged from other canvas, do that way.
             *    c. If the canvas is not empty and the item dragged from listbox, do not drop.
             *    d. If the canvas is not empty and the item dragged from other canvas, switch.
             * 2. Update PuzzleItemPlacement
             * 3. Remove that item from its source (listbox/canvas) if it is not switched
             * 4. Raise the event puzzle changed then check if the puzzle valid
             * 5. Delete DragFrom properties
             */

            //Step 1
            //Get the item dropped...
            Canvas destination = sender as Canvas;

            PuzzlePiece itemTransferred = null;

            object data = e.Data.GetData(typeof(PuzzlePiece)) as PuzzlePiece;

            itemTransferred = data as PuzzlePiece;

            Image imageControl = new Image()
            {
                Width = destination.Width,
                Height = destination.Height,
                Source = itemTransferred.PuzzleImageSource,
                Stretch = Stretch.UniformToFill
            };

            //For condition 1 a and b, canvas is empty
            if (destination.Children.Count == 0)
            {
                //put the puzzle piece to the canvas
                destination.Children.Add(imageControl);

                //Step 2
                //Update PuzzleItemPlacement
                //get the placement index to be updated
                int indexToUpdate = int.Parse(destination.Tag.ToString());

                //update now
                //this statement is for condition 1 a (item from listbox)
                if (itemTransferred.DragFrom == typeof(ListBox))
                {
                    //update
                    this.itemPlacement[indexToUpdate] = itemTransferred;

                    //Step 3
                    //delete the item dragged from listbox
                    //NOTE : DELETING this way makes puzzle pieces defined in puzzle.puzzleItem DELETED
                    ((IList)lbDragSource.ItemsSource).Remove(itemTransferred);
                }

                //this statement is for condition 1 a (item from listbox)
                else if (itemTransferred.DragFrom == typeof(Canvas))
                {
                    //if the item is from other canvas,
                    //it means that the previous canvas where the item put is empty
                    //update the old placement
                    //get the index
                    int previousIndex = itemPlacement.IndexOf(itemTransferred);

                    //update for new placement
                    itemPlacement[indexToUpdate] = itemTransferred;

                    //Step 3
                    //delete the item dragged from listbox
                    //make null to the previous canvas
                    itemPlacement[previousIndex] = emptyItem;

                    //delete the picture
                    Canvas associated = GetAssociatedCanvasByIndex(previousIndex);

                    associated.Children.Clear();

                    associated = null;
                }
                else
                {
                    MessageBox.Show("Dragsource is not from listbox or canvas");
                }
            }

            //for condition 1 c and d
            //canvas is not empty
            else if (destination.Children.Count > 0)
            {
                //condition 1c, from listbox
                if (itemTransferred.DragFrom == typeof(ListBox))
                {
                    //do nothing
                    return;
                }

                //condition 1d
                else if (itemTransferred.DragFrom == typeof(Canvas))
                {
                    //Step 1 and 2, switch them
                    //get the previous and destination index
                    int sourceIndex = itemPlacement.IndexOf(itemTransferred);

                    int destinationIndex = int.Parse(destination.Tag.ToString());

                    Object buffer = null;

                    //switch the image
                    Image image0 = new Image() { Width = destination.Width, Height = destination.Height, Stretch = Stretch.Fill };

                    image0.Source = itemPlacement[sourceIndex].PuzzleImageSource;

                    Image image1 = new Image() { Width = destination.Width, Height = destination.Height, Stretch = Stretch.Fill };

                    image1.Source = itemPlacement[destinationIndex].PuzzleImageSource;

                    GetAssociatedCanvasByIndex(sourceIndex).Children.Clear();

                    GetAssociatedCanvasByIndex(destinationIndex).Children.Clear();

                    GetAssociatedCanvasByIndex(sourceIndex).Children.Add(image1);

                    GetAssociatedCanvasByIndex(destinationIndex).Children.Add(image0);

                    image0 = null;

                    image1 = null;

                    //switch the placement
                    buffer = itemPlacement[sourceIndex];

                    itemPlacement[sourceIndex] = itemPlacement[destinationIndex];

                    itemPlacement[destinationIndex] = buffer as PuzzlePiece;

                    buffer = null;
                }
            }

            //Step 4
            //Raise the event puzzle changed then check if the puzzle valid
            puzzle.OnEdit(EventArgs.Empty);

            //Step 5
            //Delete DragFrom properties
            itemTransferred.DragFrom = null;
        }

        #endregion

        #region puzzle piece edited handler

        void puzzle_Edited(object sender, EventArgs e)
        {
            bool validate = puzzle.Validate(itemPlacement);

            if (validate)
            {
                MessageBox.Show("Congratulations. You solve the puzzle!");
            }
        }

        #endregion

        #region method to get associated canvas :D

        private Canvas GetAssociatedCanvasByIndex(int index)
        {
            int i = index;

            if (i == 0)
                return puzzlePart1;
            else if (i == 1)
                return puzzlePart2;
            else if (i == 2)
                return puzzlePart3;
            else if (i == 3)
                return puzzlePart4;
            else if (i == 4)
                return puzzlePart5;
            else if (i == 5)
                return puzzlePart6;
            else if (i == 6)
                return puzzlePart7;
            else if (i == 7)
                return puzzlePart8;
            else if (i == 8)
                return puzzlePart9;

            return null;
        }

        #endregion

        #region Methods to get data from dragging

        private object GetDataFromCanvas(Canvas cvDragSource)
        {
            //first get the index
            int canvasIndex = int.Parse(cvDragSource.Tag.ToString());

            //get the puzzle piece based on the puzzle placement
            PuzzlePiece item = itemPlacement[canvasIndex];

            return item;
        }

        /// <summary>
        /// Method used to get data from list box's item which is
        /// dragged
        /// </summary>
        /// <param name="dragSource"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        private object GetObjectDataFromPoint(ListBox dragSource, Point point)
        {
            UIElement element = dragSource.InputHitTest(point) as UIElement;

            //MessageBox.Show("Drag Source Element : " + element.ToString());

            if (element != null)
            {
                object data = DependencyProperty.UnsetValue;

                while (data == DependencyProperty.UnsetValue)
                {
                    data = dragSource.ItemContainerGenerator.ItemFromContainer(element);

                    if (data == DependencyProperty.UnsetValue)
                    {
                        element = VisualTreeHelper.GetParent(element) as UIElement;

                        //MessageBox.Show("Element passed through : " + element.ToString());
                    }

                    if (element == dragSource)
                    {
                        return null;

                        //MessageBox.Show("element == dragSource");
                    }
                }

                if (data != DependencyProperty.UnsetValue)
                {
                    //MessageBox.Show("Data : " + data.ToString());

                    return data;
                }
            }
            return null;
        }

        #endregion

        #region instruction button

        private void instruction_Click(object sender, RoutedEventArgs e)
        {
            string instruction = "Sleep het puzzelstukje en zet het neer in het juiste vak.\n Je kunt schakelen tussen de vakjes, maar je kunt het puzzelstukje niet terugzetten in de lijst aan de linkerkant..";
            
            MessageBox.Show(instruction);
        }

        #endregion

        #region Home Button

        private void Roundedbutton_Click(object sender, RoutedEventArgs e)
        {
            Eindscherm endgame = new Eindscherm();
            endgame.Show();
            this.Close();
        }

            #endregion

        }
}