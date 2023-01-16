using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Labyrinth
{
    public partial class frmLabyrinth : Form
    {
        public struct Case
        {
            public bool Wall;
            public int cout;
            public int x;
            public int y;
            public int heurisitc;
            public int heuristic_plus_cout;
        }

        bool Go_left;
        bool Go_right;
        bool Go_up;
        bool Go_down;
        Stopwatch stopwatch = new Stopwatch();
        TimeSpan elapsedTime;

        Case[,] cases;
        List<Case> child_cell_up = new List<Case>();
        List<Case> child_cell_down = new List<Case>();
        List<Case> child_cell_left = new List<Case>();
        List<Case> child_cell_right = new List<Case>();
        List<Case> explored = new List<Case>();
        List<Case> frontier = new List<Case>();

        //List pour iterative deepening
        List<Case> List_Go_up = new List<Case>();
        List<Case> List_Go_Down = new List<Case>();
        List<Case> List_Go_Left = new List<Case>();
        List<Case> List_Go_Right = new List<Case>();
        Graphics g;

        int start_x = 7;
        int start_y = 7;
        int end_x = 29;
        int end_y = 29;
        public int affichage = 0;

        //int affichage = 0;
        public frmLabyrinth()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            cases = new Case[31, 31];


            //################################################### CREATION DU LABYRINTHE ICI##############################################

            // remplir le tableau mur
            for (int i = 0; i < 31; i++)
            {
                cases[0, i].Wall = true;
                cases[0, i].cout = 0;
                cases[30, i].Wall = true;
                cases[30, i].cout = 0;
            }

            //remplir le tableau mur verticale
            for (int i = 0; i < 31; i++)
            {
                cases[i, 0].Wall = true;
                cases[i, 0].cout = 0;
                cases[i, 30].Wall = true;
                cases[i, 30].cout = 0;
            }

            for (int i = 0; i < 31; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    cases[i, j].x = i;
                    cases[i, j].y = j;
                }
            }

            //entrée du laby
            cases[start_x, start_y].Wall = false;
            //sorti du laby
            cases[end_x, end_y].Wall = false;

            ItsAWall(1, 12, 1);
            ItsAWall(1, 20, 1);
            ItsAWall(1, 28, 1);

            ItsAWall(2, 2, 9);
            ItsAWall(2, 12, 3);
            ItsAWall(2, 16, 5);
            ItsAWall(2, 22, 1);
            ItsAWall(2, 24, 3);
            ItsAWall(2, 28, 1);

            ItsAWall(3, 10, 1);
            ItsAWall(3, 22, 1);
            ItsAWall(3, 24, 1);

            ItsAWall(4, 2, 1);
            ItsAWall(4, 4, 3);
            ItsAWall(4, 8, 3);
            ItsAWall(4, 12, 9);
            ItsAWall(4, 22, 5);
            ItsAWall(4, 28, 2);

            ItsAWall(5, 2, 1);
            ItsAWall(5, 4, 1);
            ItsAWall(5, 10, 1);
            ItsAWall(5, 12, 1);
            ItsAWall(5, 20, 1);
            ItsAWall(5, 22, 1);
            ItsAWall(5, 24, 1);

            ItsAWall(6, 1, 6);
            ItsAWall(6, 8, 3);
            ItsAWall(6, 12, 7);
            ItsAWall(6, 20, 1);
            ItsAWall(6, 22, 1);
            ItsAWall(6, 24, 3);
            ItsAWall(6, 28, 2);

            ItsAWall(7, 12, 1);
            ItsAWall(7, 22, 1);
            ItsAWall(7, 24, 1);
            ItsAWall(7, 26, 1);

            ItsAWall(8, 1, 2);
            ItsAWall(8, 4, 5);
            ItsAWall(8, 10, 9);
            ItsAWall(8, 20, 3);
            ItsAWall(8, 24, 1);
            ItsAWall(8, 26, 1);
            ItsAWall(8, 28, 1);

            ItsAWall(9, 2, 1);
            ItsAWall(9, 4, 1);
            ItsAWall(9, 10, 1);
            ItsAWall(9, 14, 1);
            ItsAWall(9, 18, 1);
            ItsAWall(9, 24, 1);
            ItsAWall(9, 28, 1);

            ItsAWall(10, 2, 1);
            ItsAWall(10, 4, 1);
            ItsAWall(10, 6, 5);
            ItsAWall(10, 12, 3);
            ItsAWall(10, 16, 1);
            ItsAWall(10, 18, 3);
            ItsAWall(10, 22, 3);
            ItsAWall(10, 26, 3);

            ItsAWall(11, 4, 1);
            ItsAWall(11, 6, 1);
            ItsAWall(11, 8, 1);
            ItsAWall(11, 10, 1);
            ItsAWall(11, 16, 1);
            ItsAWall(11, 22, 1);
            ItsAWall(11, 24, 1);

            ItsAWall(12, 1, 4);
            ItsAWall(12, 6, 1);
            ItsAWall(12, 8, 1);
            ItsAWall(12, 10, 3);
            ItsAWall(12, 14, 1);
            ItsAWall(12, 16, 3);
            ItsAWall(12, 20, 1);
            ItsAWall(12, 22, 1);
            ItsAWall(12, 24, 3);
            ItsAWall(12, 28, 1);

            ItsAWall(13, 2, 1);
            ItsAWall(13, 8, 1);
            ItsAWall(13, 10, 1);
            ItsAWall(13, 12, 1);
            ItsAWall(13, 14, 1);
            ItsAWall(13, 16, 1);
            ItsAWall(13, 18, 1);
            ItsAWall(13, 20, 1);
            ItsAWall(13, 24, 1);
            ItsAWall(13, 28, 1);

            ItsAWall(14, 2, 3);
            ItsAWall(14, 6, 3);
            ItsAWall(14, 10, 1);
            ItsAWall(14, 12, 1);
            ItsAWall(14, 14, 3);
            ItsAWall(14, 18, 1);
            ItsAWall(14, 20, 1);
            ItsAWall(14, 22, 3);
            ItsAWall(14, 26, 3);

            ItsAWall(15, 6, 1);
            ItsAWall(15, 14, 1);
            ItsAWall(15, 18, 1);
            ItsAWall(15, 20, 1);
            ItsAWall(15, 28, 1);

            ItsAWall(16, 2, 5);
            ItsAWall(16, 8, 1);
            ItsAWall(16, 10, 1);
            ItsAWall(16, 12, 1);
            ItsAWall(16, 14, 1);
            ItsAWall(16, 16, 1);
            ItsAWall(16, 18, 3);
            ItsAWall(16, 22, 1);
            ItsAWall(16, 24, 3);
            ItsAWall(16, 28, 2);

            ItsAWall(17, 2, 1);
            ItsAWall(17, 4, 1);
            ItsAWall(17, 8, 1);
            ItsAWall(17, 10, 1);
            ItsAWall(17, 12, 1);
            ItsAWall(17, 16, 1);
            ItsAWall(17, 18, 1);
            ItsAWall(17, 22, 1);
            ItsAWall(17, 24, 1);
            ItsAWall(17, 28, 1);

            ItsAWall(18, 2, 1);
            ItsAWall(18, 4, 3);
            ItsAWall(18, 8, 5);
            ItsAWall(18, 14, 1);
            ItsAWall(18, 16, 1);
            ItsAWall(18, 18, 3);
            ItsAWall(18, 22, 3);
            ItsAWall(18, 26, 1);
            ItsAWall(18, 28, 1);

            ItsAWall(19, 6, 1);
            ItsAWall(19, 8, 1);
            ItsAWall(19, 10, 1);
            ItsAWall(19, 14, 1);
            ItsAWall(19, 16, 1);
            ItsAWall(19, 22, 1);
            ItsAWall(19, 26, 1);

            ItsAWall(20, 2, 3);
            ItsAWall(20, 6, 1);
            ItsAWall(20, 8, 1);
            ItsAWall(20, 10, 7);
            ItsAWall(20, 18, 5);
            ItsAWall(20, 24, 5);

            ItsAWall(21, 2, 1);
            ItsAWall(21, 12, 1);
            ItsAWall(21, 22, 1);
            ItsAWall(21, 24, 1);
            ItsAWall(21, 26, 1);
            ItsAWall(21, 28, 1);

            ItsAWall(22, 2, 1);
            ItsAWall(22, 4, 1);
            ItsAWall(22, 6, 3);
            ItsAWall(22, 10, 3);
            ItsAWall(22, 14, 1);
            ItsAWall(22, 16, 1);
            ItsAWall(22, 18, 3);
            ItsAWall(22, 22, 3);
            ItsAWall(22, 26, 1);
            ItsAWall(22, 28, 1);

            ItsAWall(23, 2, 1);
            ItsAWall(23, 4, 1);
            ItsAWall(23, 6, 1);
            ItsAWall(23, 14, 1);
            ItsAWall(23, 16, 1);
            ItsAWall(23, 18, 1);
            ItsAWall(23, 22, 1);
            ItsAWall(23, 28, 1);

            ItsAWall(24, 1, 2);
            ItsAWall(24, 4, 3);
            ItsAWall(24, 8, 3);
            ItsAWall(24, 12, 1);
            ItsAWall(24, 14, 5);
            ItsAWall(24, 20, 3);
            ItsAWall(24, 24, 1);
            ItsAWall(24, 26, 1);
            ItsAWall(24, 28, 1);

            ItsAWall(25, 6, 1);
            ItsAWall(25, 8, 1);
            ItsAWall(25, 12, 1);
            ItsAWall(25, 14, 1);
            ItsAWall(25, 22, 1);
            ItsAWall(25, 24, 1);
            ItsAWall(25, 26, 1);
            ItsAWall(25, 28, 1);

            ItsAWall(26, 1, 4);
            ItsAWall(26, 6, 1);
            ItsAWall(26, 8, 1);
            ItsAWall(26, 10, 5);
            ItsAWall(26, 16, 1);
            ItsAWall(26, 18, 3);
            ItsAWall(26, 22, 1);
            ItsAWall(26, 24, 1);
            ItsAWall(26, 26, 3);

            ItsAWall(27, 6, 1);
            ItsAWall(27, 8, 1);
            ItsAWall(27, 10, 1);
            ItsAWall(27, 16, 1);
            ItsAWall(27, 18, 1);
            ItsAWall(27, 22, 1);
            ItsAWall(27, 24, 1);
            ItsAWall(27, 28, 1);

            ItsAWall(28, 2, 3);
            ItsAWall(28, 6, 3);
            ItsAWall(28, 10, 1);
            ItsAWall(28, 12, 5);
            ItsAWall(28, 18, 1);
            ItsAWall(28, 20, 1);
            ItsAWall(28, 22, 3);
            ItsAWall(28, 26, 3);

            ItsAWall(29, 14, 1);
            ItsAWall(29, 18, 1);
            ItsAWall(29, 20, 1);
        }
        //################################################### FIN CREATION DU LABYRINTHE ICI###########################################

        private void frmLabyrinth_Load(object sender, EventArgs e)
        {
            picGameBoard.Image = new Bitmap(620, 620);
            g = Graphics.FromImage(picGameBoard.Image);
            for (int i = 0; i < 31; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if (cases[i, j].Wall == true)
                    {
                        g.FillRectangle(Brushes.Black, j * 20, i * 20, 20, 20);
                    }
                }
            }

            Random rnd = new Random();
            for (int i = 0; i < 31; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if (cases[i, j].Wall == false)
                    {
                        //On attribue a chaque case un cout entre 1 et 5 de facon random
                        //faut mettre 6 pcq la methode c'est >=1 et <6
                        cases[i, j].cout = rnd.Next(1,6); ;
                    }
                }
            }
        }

        private void ItsAWall(int i, int j, int NumberOfWallls)
        {
            for (int k = 0; k < NumberOfWallls; k++)
            {
                cases[i, j].Wall = true;
                j++;
            }
        }


        public void DFS()
        {
            int current_x = start_x;
            int current_y = start_y;
            frontier.Add(cases[current_x, current_y]);
            while (frontier.Count > 0)
            {
                if(current_x == end_x && current_y == end_y)
                {
                    Console.WriteLine("Arrive à la sortie");
                    explored.RemoveAt(explored.Count - 1);
                    frontier.Clear();
                }
                else
                {
                    Go_left = Go_right = Go_up = Go_down = false;
                    current_x = frontier[frontier.Count - 1].x;
                    current_y = frontier[frontier.Count - 1].y;
                    explored.Add(cases[current_x, current_y]);
                    frontier.RemoveAt(frontier.Count - 1);
                    //Mouvement vers le bas en premier car first in last out
                    if (current_x +1 <31 && cases[current_x+1, current_y].Wall == false && explored.Contains(cases[current_x + 1, current_y]) == false)
                    {
                        frontier.Add(cases[current_x + 1, current_y]);
                        Go_down = true;
                    }if (current_y+1 < 31 && cases[current_x, current_y+1].Wall == false && explored.Contains(cases[current_x, current_y + 1]) == false)
                    {
                        frontier.Add(cases[current_x, current_y+1]);
                        Go_right = true;
                    }if (current_y - 1 >=0 && cases[current_x, current_y - 1].Wall == false && explored.Contains(cases[current_x, current_y - 1]) == false)
                    {
                        frontier.Add(cases[current_x, current_y - 1]);
                        Go_left = true;
                    }if (current_x - 1 >=0 && cases[current_x - 1, current_y].Wall == false && explored.Contains(cases[current_x - 1, current_y]) == false)
                    {
                        frontier.Add(cases[current_x-1, current_y]);
                        Go_up = true;
                    }
                    if(Go_up == true && explored.Contains(frontier[frontier.Count-1]) == false)
                    {
                        explored.Add(frontier[frontier.Count-1]);
                    }
                    else if(Go_left == true && explored.Contains(frontier[frontier.Count-1]) == false )
                    {
                        explored.Add(frontier[frontier.Count-1]);
                    }
                    else if(Go_right == true && explored.Contains(frontier[frontier.Count-1]) == false )
                    {
                        explored.Add(frontier[frontier.Count - 1] );
                    }
                    else if(Go_down == true && explored.Contains(frontier[frontier.Count - 1]) == false)
                    {
                        explored.Add(frontier[frontier.Count-1]);
                    }
                }
            }
        }

        //Meme chose que DFS sauf avec une profoondeur max qui est set par l'utilisateur

        public int Manathan_Start_Frontier(int x, int y)
        {
            return Math.Abs(start_x - x) + Math.Abs(start_y - y);
        }
        public void Iterative_Deepening()
        {
            bool Get_by_up = false;
            bool Get_by_down = false;
            bool Get_by_left = false;
            bool Get_by_right = false;
            bool Goal_reached_or_not = false;

            int deepening = Convert.ToInt32(textBoxdeep.Text);
            if(deepening <= 0)
            {
                MessageBox.Show("Merci de rentrer une profondeur valide, c'est à dire >0");
            }
            else
            {
                int current_x = start_x;
                int current_y = start_y;
                frontier.Add(cases[current_x, current_y]);
                //explored.Add(frontier[0]);
                List_Go_Down.Add(frontier[0]);
                List_Go_Left.Add(frontier[0]);
                List_Go_Right.Add(frontier[0]);
                List_Go_up.Add(frontier[0]);
                int current_deep = 0;

                //if (start_x - 1 >= 0 && cases[start_x - 1, start_y].Wall == false)
                //{
                //    frontier.Clear();
                //    frontier.Add(cases[start_x-1,start_y]);
                //    List_Go_up.Add(frontier[frontier.Count-1]);
                //    while (List_Go_up.Count <= deepening && frontier.Count>0)
                //    {
                //        Console.WriteLine("Condition arret");
                //        if(current_x == end_x && current_y == end_y && List_Go_up.Count -1 <= deepening)
                //        {
                //            Console.WriteLine("Goal trouvé à la profondeur {0}", List_Go_up.Count);
                //            frontier.Clear();
                //            Get_by_up = true;
                //        }
                //        else
                //        {
                //            Go_left = Go_right = Go_up = Go_down = false;
                //            current_x = frontier[frontier.Count - 1].x;
                //            current_y = frontier[frontier.Count - 1].y;
                //            List_Go_up.Add(frontier[frontier.Count - 1]);
                //            frontier.RemoveAt(frontier.Count - 1);

                //            if (current_x + 1 < 31 && cases[current_x + 1, current_y].Wall == false && List_Go_up.Contains(cases[current_x + 1, current_y]) == false)
                //            {
                //                frontier.Add(cases[current_x + 1, current_y]);
                //                Go_down = true;
                //            }
                //            if (current_y + 1 < 31 && cases[current_x, current_y + 1].Wall == false && List_Go_up.Contains(cases[current_x, current_y + 1]) == false)
                //            {
                //                frontier.Add(cases[current_x, current_y + 1]);
                //                Go_right = true;
                //            }
                //            if (current_y - 1 >= 0 && cases[current_x, current_y - 1].Wall == false && List_Go_up.Contains(cases[current_x, current_y - 1]) == false)
                //            {
                //                frontier.Add(cases[current_x, current_y - 1]);
                //                Go_left = true;
                //            }
                //            if (current_x - 1 >= 0 && cases[current_x - 1, current_y].Wall == false && List_Go_up.Contains(cases[current_x - 1, current_y]) == false)
                //            {
                //                frontier.Add(cases[current_x - 1, current_y]);
                //                Go_up = true;
                //            }
                //        }
                //    }
                //}

                //POUR ALLER A GAUCHE SI ON PEUT PAS ALLER EN HAUT A LA CASE DE DEPART
                if (start_y - 1 >= 0 && cases[start_x, start_y - 1].Wall == false && Get_by_up == false)
                {
                    frontier.Clear();
                    List_Go_Left.Add(cases[start_x, start_y]);
                    frontier.Add(cases[start_x, start_y - 1]);
                    List_Go_Left.Add(frontier[frontier.Count - 1]);
                    while (Goal_reached_or_not == false && frontier.Count > 0)
                    {
                        if (current_x == end_x && current_y == end_y && child_cell_up.Count - 1 <= deepening)
                        {
                            Console.WriteLine("Goal trouvé à la profondeur {0}", child_cell_up.Count);
                            frontier.Clear();
                            Get_by_left = true;
                        }
                        else
                        {
                            Go_left = Go_right = Go_up = Go_down = false;
                            current_x = frontier[frontier.Count - 1].x;
                            current_y = frontier[frontier.Count - 1].y;
                            current_deep = Manathan_Start_Frontier(current_x, current_y);
                            List_Go_Left.Add(frontier[frontier.Count - 1]);
                            frontier.RemoveAt(frontier.Count - 1);

                            //Mouvement vers le bas en premier car first in last out
                            if (current_x + 1 < 31 && cases[current_x + 1, current_y].Wall == false && current_deep < deepening)
                            {
                                child_cell_down.Add(cases[current_x + 1, current_y]);
                                Go_down = true;
                            }
                            if (current_y + 1 < 31 && cases[current_x, current_y + 1].Wall == false && current_deep < deepening)
                            {
                                child_cell_right.Add(cases[current_x, current_y + 1]);
                                Go_right = true;
                            }
                            if (current_y - 1 >= 0 && cases[current_x, current_y - 1].Wall == false && current_deep < deepening)
                            {
                                child_cell_left.Add(cases[current_x, current_y - 1]);
                                Go_left = true;
                            }
                            if (current_x - 1 >= 0 && cases[current_x - 1, current_y].Wall == false && current_deep < deepening)
                            {
                                child_cell_up.Add(cases[current_x - 1, current_y]);
                                Go_up = true;
                            }

                            if (Go_down == true && List_Go_Left.Contains(child_cell_down[child_cell_down.Count - 1]) == false)
                            {
                                frontier.Add(child_cell_down[child_cell_down.Count - 1]);
                            }
                            if (Go_right == true && List_Go_Left.Contains(child_cell_right[child_cell_right.Count - 1]) == false)
                            {
                                frontier.Add(child_cell_right[child_cell_right.Count - 1]);
                            }
                            if (Go_left == true && List_Go_Left.Contains(child_cell_left[child_cell_left.Count - 1]) == false)
                            {
                                frontier.Add(child_cell_left[child_cell_left.Count - 1]);
                            }
                            if (Go_up == true && List_Go_Left.Contains(child_cell_up[child_cell_up.Count - 1]) == false)
                            {
                                frontier.Add(child_cell_up[child_cell_up.Count - 1]);
                            }

                            if(child_cell_down.Count == deepening && child_cell_left.Count == deepening && child_cell_right.Count == deepening && child_cell_up.Count == deepening)
                            {
                                Goal_reached_or_not = true;
                            }
                        }
                    }

                }

                ////POUR ALLER A Droite SI ON PEUT PAS ALLER EN HAUT A LA CASE DE DEPART
                //if (start_y + 1 < 31 && cases[start_x, start_y + 1].Wall == false && Get_by_left == false && Get_by_up == false)
                //{
                //    frontier.Clear();
                //    frontier.Add(cases[start_x, start_y + 1]);
                //    List_Go_Right.Add(frontier[frontier.Count - 1]);
                //    while (List_Go_Right.Count <= deepening && frontier.Count > 0)
                //    {
                //        if (current_x == end_x && current_y == end_y && List_Go_Right.Count - 1 <= deepening)
                //        {
                //            Console.WriteLine("Goal trouvé à la profondeur {0}", List_Go_Right.Count);
                //            frontier.Clear();
                //            Get_by_right = true;
                //        }
                //        else
                //        {
                //            Go_left = Go_right = Go_up = Go_down = false;
                //            current_x = frontier[frontier.Count - 1].x;
                //            current_y = frontier[frontier.Count - 1].y;
                //            List_Go_Right.Add(frontier[frontier.Count - 1]);
                //            frontier.RemoveAt(frontier.Count - 1);

                //            if (current_x + 1 < 31 && cases[current_x + 1, current_y].Wall == false && List_Go_Right.Contains(cases[current_x + 1, current_y]) == false)
                //            {
                //                //child_cell_down.Clear();
                //                //child_cell_down.Add(cases[current_x+1,current_y]);
                //                frontier.Add(cases[current_x + 1, current_y]);
                //                Go_down = true;
                //            }
                //            if (current_y + 1 < 31 && cases[current_x, current_y + 1].Wall == false && List_Go_Right.Contains(cases[current_x, current_y + 1]) == false)
                //            {
                //                //child_cell_right.Clear();
                //                frontier.Add(cases[current_x, current_y + 1]);
                //                Go_right = true;
                //            }
                //            if (current_y - 1 >= 0 && cases[current_x, current_y - 1].Wall == false && List_Go_Right.Contains(cases[current_x, current_y - 1]) == false)
                //            {
                //                //child_cell_left.Clear();
                //                frontier.Add(cases[current_x, current_y - 1]);
                //                Go_left = true;
                //            }
                //            if (current_x - 1 >= 0 && cases[current_x - 1, current_y].Wall == false && List_Go_Right.Contains(cases[current_x - 1, current_y]) == false)
                //            {
                //                //child_cell_up.Clear();
                //                frontier.Add(cases[current_x - 1, current_y]);
                //                Go_up = true;
                //            }
                //        }
                //    }

                //}

                //POUR ALLER en bas SI ON PEUT PAS ALLER a droite A LA CASE DE DEPART
                //if (start_x + 1 < 31 && cases[start_x + 1, start_y].Wall == false && Get_by_right == false && Get_by_left == false && Get_by_up == false)
                //{
                //    frontier.Clear();
                //    frontier.Add(cases[start_x + 1, start_y]);
                //    List_Go_Down.Add(frontier[frontier.Count - 1]);
                //    while (List_Go_Down.Count <= deepening && frontier.Count > 0)
                //    {
                //        if (current_x == end_x && current_y == end_y && List_Go_Down.Count - 1 <= deepening)
                //        {
                //            Console.WriteLine("Goal trouvé à la profondeur {0}", List_Go_Down.Count);
                //            frontier.Clear();
                //            Get_by_down = true;
                //        }
                //        else
                //        {
                //            Go_left = Go_right = Go_up = Go_down = false;
                //            current_x = frontier[frontier.Count - 1].x;
                //            current_y = frontier[frontier.Count - 1].y;
                //            List_Go_Down.Add(frontier[frontier.Count - 1]);
                //            frontier.RemoveAt(frontier.Count - 1);

                //            //Mouvement vers le bas en premier car first in last out
                //            if (current_x + 1 < 31 && cases[current_x + 1, current_y].Wall == false && List_Go_Down.Contains(cases[current_x + 1, current_y]) == false)
                //            {
                //                //child_cell_down.Clear();
                //                //child_cell_down.Add(cases[current_x+1,current_y]);
                //                frontier.Add(cases[current_x + 1, current_y]);
                //                Go_down = true;
                //            }
                //            if (current_y + 1 < 31 && cases[current_x, current_y + 1].Wall == false && List_Go_Down.Contains(cases[current_x, current_y + 1]) == false)
                //            {
                //                //child_cell_right.Clear();
                //                frontier.Add(cases[current_x, current_y + 1]);
                //                Go_right = true;
                //            }
                //            if (current_y - 1 >= 0 && cases[current_x, current_y - 1].Wall == false && List_Go_Down.Contains(cases[current_x, current_y - 1]) == false)
                //            {
                //                //child_cell_left.Clear();
                //                frontier.Add(cases[current_x, current_y - 1]);
                //                Go_left = true;
                //            }
                //            if (current_x - 1 >= 0 && cases[current_x - 1, current_y].Wall == false && List_Go_Down.Contains(cases[current_x - 1, current_y]) == false)
                //            {
                //                //child_cell_up.Clear();
                //                frontier.Add(cases[current_x - 1, current_y]);
                //                Go_up = true;
                //            }
                //        }
                //    }
                //}

            }

            explored.AddRange(List_Go_up);
            explored.AddRange(List_Go_Left);
            explored.AddRange(List_Go_Right);
            explored.AddRange(List_Go_Down);

        }

        //Consiste en un DFS en utlisant l'heuristique -> Distance Manathan (Distance Horizontale + Distance verticale de chaque brique par rapport à sa destination finale)

        public int Manathan_Distance(int x, int y)
        {
            return Math.Abs(end_x - x) + Math.Abs(end_y - y);
        }
        public void Hill_Climbing()
        {
            List<Case> intermediar_list_for_sort = new List<Case>();
            int current_x = start_x;
            int current_y = start_y;
            frontier.Add(cases[current_x, current_y]);
            explored.Add(frontier[0]);
            while(frontier.Count > 0)
            {
                intermediar_list_for_sort.Clear();
                if (current_x == end_x && current_y == end_y)
                {
                    Console.WriteLine("Arrive à la sortie");
                    explored.RemoveAt(explored.Count - 1);
                    frontier.Clear();
                }
                else
                {
                    current_x = frontier[frontier.Count - 1].x;
                    current_y = frontier[frontier.Count - 1].y;
                    explored.Add(cases[current_x, current_y]);
                    frontier.RemoveAt(frontier.Count - 1);
                    if (current_x + 1 < 31 && cases[current_x + 1, current_y].Wall == false)
                    {
                        cases[current_x +1, current_y].heurisitc = Manathan_Distance(current_x+1, current_y);
                        intermediar_list_for_sort.Add(cases[current_x + 1, current_y]);
                    }
                    if (current_y + 1 < 31 && cases[current_x, current_y + 1].Wall == false)
                    {
                        cases[current_x, current_y+1].heurisitc = Manathan_Distance(current_x, current_y+1);
                        intermediar_list_for_sort.Add(cases[current_x, current_y + 1]);
                    }
                    if (current_y - 1 >= 0 && cases[current_x, current_y - 1].Wall == false)
                    {
                        cases[current_x, current_y - 1].heurisitc = Manathan_Distance(current_x, current_y - 1 );
                        intermediar_list_for_sort.Add(cases[current_x, current_y - 1]);
                    }
                    if (current_x - 1 >= 0 && cases[current_x - 1, current_y].Wall == false)
                    {
                        cases[current_x - 1, current_y].heurisitc = Manathan_Distance(current_x - 1, current_y);
                        intermediar_list_for_sort.Add(cases[current_x - 1, current_y]);
                    }
                    //trier la liste en fonction de l'heurstic facon croissante
                    intermediar_list_for_sort.Sort((x, y) => x.heurisitc.CompareTo(y.heurisitc));
                    //ajouter de facon decroissante ici !!!!
                    for(int i = intermediar_list_for_sort.Count-1; i >=0 ; i--)
                    {
                        if(explored.Contains(intermediar_list_for_sort[i]) == false)
                        {
                            frontier.Add(intermediar_list_for_sort[i]);
                        }
                    }
                    explored.Add(frontier[frontier.Count-1]);
                }
            }
        }

        public void Greedy_Search()
        {
            List<Case> intermediar_list_for_sort = new List<Case>();
            int current_x = start_x;
            int current_y = start_y;
            frontier.Add(cases[current_x, current_y]);
            explored.Add(frontier[0]);
            while (frontier.Count > 0)
            {
                intermediar_list_for_sort.Clear();
                if (current_x == end_x && current_y == end_y)
                {
                    Console.WriteLine("Arrive à la sortie");
                    explored.RemoveAt(explored.Count - 1);
                    frontier.Clear();
                }
                else
                {
                    current_x = frontier[0].x;
                    current_y = frontier[0].y;
                    explored.Add(cases[current_x, current_y]);
                    frontier.RemoveAt(0);
                    if (current_x + 1 < 31 && cases[current_x + 1, current_y].Wall == false)
                    {
                        cases[current_x + 1, current_y].heurisitc = Manathan_Distance(current_x + 1, current_y);
                        intermediar_list_for_sort.Add(cases[current_x + 1, current_y]);
                    }
                    if (current_y + 1 < 31 && cases[current_x, current_y + 1].Wall == false)
                    {
                        cases[current_x, current_y + 1].heurisitc = Manathan_Distance(current_x, current_y + 1);
                        intermediar_list_for_sort.Add(cases[current_x, current_y + 1]);
                    }
                    if (current_y - 1 >= 0 && cases[current_x, current_y - 1].Wall == false)
                    {
                        cases[current_x, current_y - 1].heurisitc = Manathan_Distance(current_x, current_y - 1);
                        intermediar_list_for_sort.Add(cases[current_x, current_y - 1]);
                    }
                    if (current_x - 1 >= 0 && cases[current_x - 1, current_y].Wall == false)
                    {
                        cases[current_x - 1, current_y].heurisitc = Manathan_Distance(current_x - 1, current_y);
                        intermediar_list_for_sort.Add(cases[current_x - 1, current_y]);
                    }
                    //trier la liste en fonction de l'heurstic facon croissante
                    intermediar_list_for_sort.Sort((x, y) => x.heurisitc.CompareTo(y.heurisitc));
                    //ajouter de facon decroissante ici !!!!
                    for (int i = intermediar_list_for_sort.Count - 1; i >= 0; i--)
                    {
                        if (explored.Contains(intermediar_list_for_sort[i]) == false)
                        {
                            frontier.Add(intermediar_list_for_sort[i]);
                        }
                    }

                    //Trier frontier de facon croissante
                    frontier.Sort((x, y) => x.heurisitc.CompareTo(y.heurisitc));
                    explored.Add(frontier[0]);
                }
            }

        }

        public void Cout_Plus_Heuristic()
        {
            for(int i = 0; i<31; i++)
            {
                for(int j = 0; j < 31; j++)
                {
                    if (cases[i,j].Wall == false)
                    {
                        cases[i,j].heuristic_plus_cout = Manathan_Distance(cases[i,j].x, cases[i,j].y) + cases[i,j].cout;
                    }
                }
            }
        }

        public void A_Star()
        {
            Cout_Plus_Heuristic();
            //la case de depart n'a pas de cout
            cases[start_x,start_y].cout = 0;
            frontier.Add(cases[start_x, start_y]);
            int current_x = start_x; ;
            int current_y = start_y;
            explored.Add(frontier[0]);
            while(frontier.Count > 0)
            {
                current_x = frontier[0].x;
                current_y = frontier[0].y;
                frontier.RemoveAt(0);
                if(current_x == end_x && current_y == end_y)
                {
                    Console.WriteLine("A_Star fini objectif trouve ");
                    frontier.Clear();
                }
                else
                {
                    //voir si case du haut est accessible et qu'elle n'a pas encore visite
                    if( current_x -1 >= 0 &&cases[current_x -1,current_y].Wall == false && explored.Contains(cases[current_x-1, current_y]) == false)
                    {
                        frontier.Add(cases[current_x-1,current_y]);
                    }
                    //voir si case du bas et accessible et qu'elle n'a pas encore été visité
                    if (current_x + 1 < 31 && cases[current_x + 1, current_y].Wall == false && explored.Contains(cases[current_x + 1, current_y]) == false)
                    {
                        frontier.Add(cases[current_x + 1, current_y]);
                    }

                    //voir si case de droite et accessible et qu'elle n'a pas encore été visité
                    if (current_y + 1 < 31 && cases[current_x, current_y + 1].Wall == false && explored.Contains(cases[current_x, current_y + 1]) == false)
                    {
                        frontier.Add(cases[current_x, current_y + 1]);
                    }

                    //voir si case de gauche et accessible et qu'elle n'a pas encore été visité
                    if (current_y - 1 >= 0 && cases[current_x, current_y - 1].Wall == false && explored.Contains(cases[current_x, current_y - 1]) == false)
                    {
                        frontier.Add(cases[current_x, current_y - 1]);
                    }

                    //trier la liste frontier en fonction du cout + heurisitc de facon croissante !
                    frontier.Sort((x, y) => x.heuristic_plus_cout.CompareTo(y.heuristic_plus_cout));

                    //il se peut que des cases ou le meme cout + heuristic, si c'est le cas il faut previligier la case avec l'heuristic la + basse
                    for (int i = 0; i < frontier.Count-1; i++)
                    {
                        if (frontier[i].heuristic_plus_cout == frontier[i + 1].heuristic_plus_cout)
                        {
                            if(frontier[i+1].heurisitc < frontier[i].heurisitc)
                            {
                                Case temp = new Case();
                                temp = frontier[i];
                                frontier[i] = frontier[i + 1];
                                frontier[i +1 ] = temp;
                            }
                        }
                    }
                    explored.Add(frontier[0]);
                }
            }

        }

        private void Timer_tick_event(object sender, EventArgs e)
        {
            if (affichage < explored.Count)
            {
                g.FillRectangle(Brushes.Red, explored[affichage].y * 20, explored[affichage].x * 20, 20, 20);
                affichage++;
                picGameBoard.Refresh();
            }
            labeltemps.Text = elapsedTime.ToString();
        }

        private void Lunch_Button_Clicked(object sender, EventArgs e)
        {
            child_cell_up.Clear() ;
            child_cell_down.Clear();
            child_cell_left.Clear();
            child_cell_right.Clear();
            List_Go_up.Clear();
            List_Go_Right.Clear();
            List_Go_Left.Clear();
            List_Go_Down.Clear();
            explored.Clear();
            frontier.Clear();
            affichage = 0;
            stopwatch.Reset();

            picGameBoard.Image = new Bitmap(620, 620);
            g = Graphics.FromImage(picGameBoard.Image);
            for (int i = 0; i < 31; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if (cases[i, j].Wall == true)
                    {
                        g.FillRectangle(Brushes.Black, j * 20, i * 20, 20, 20);
                    }
                }
            }
            if(comboBox.Text.Equals("DFS") == true)
            {
                stopwatch.Start();
                DFS();
                stopwatch.Stop();
                elapsedTime = stopwatch.Elapsed;

                Console.WriteLine("Fin DFS");
                timer.Enabled = true;

            }else if(comboBox.Text.Equals("Iterative Deepening") == true)
            {
                stopwatch.Start();
                Iterative_Deepening();
                stopwatch.Stop();
                elapsedTime = stopwatch.Elapsed;
                Console.WriteLine("Fin Iterative Deepening");
                timer.Enabled = true;
            }else if(comboBox.Text.Equals("Greedy Search") == true)
            {
                stopwatch.Start();
                Greedy_Search();
                stopwatch.Stop();
                elapsedTime = stopwatch.Elapsed;
                Console.WriteLine("Fin Greedy_Search");
                timer.Enabled = true;
            }else if(comboBox.Text.Equals("Hill Climbing") == true)
            {
                stopwatch.Start();
                Hill_Climbing();
                stopwatch.Stop();
                elapsedTime = stopwatch.Elapsed;
                Console.WriteLine("Hill climbing ended");
                timer.Enabled=true;

            }else if(comboBox.Text.Equals("A*") == true)
            {
                stopwatch.Start();
                A_Star();
                stopwatch.Stop();
                elapsedTime = stopwatch.Elapsed;
                Console.WriteLine("A* ended");
                timer.Enabled = true;
            }
            else
            {
                MessageBox.Show("Pas d'algo dispo");
            }
        }
    }
}
