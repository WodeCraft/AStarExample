using AStarExample.OwnImplementation;
using AStarExample.SimpleAlgorithm;
using AStarExample.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AStarExample
{
    public partial class Form1 : Form
    {

        bool[,] World;
        Random rnd;
        Coordinate startLocation, targetLocation;
        int gridX, gridY;
        SearchParameters searchParameters;
        PathFinderParameters pathFinderParameters;
        List<Coordinate> path;

        public Form1()
        {
            InitializeComponent();

            rnd = new Random();
        }

        private void BuildGrid()
        {
            Graphics gr = gridPanel.CreateGraphics();
            Pen p = new Pen(Color.Black, 1);
            float x = 0f;
            float y = 0f;
            float xSpace = (gridPanel.Width / gridX);
            float ySpace = gridPanel.Height / gridY;

            // TODO This doesn't draw correct grid, if gridX and gridY are not the same number!!

            // Vertical lines
            for (int i = 0; i < gridY + 1; i++)
            {
                gr.DrawLine(p, x, y, x, ySpace * gridY);
                x += xSpace;
            }

            // Horizontal lines
            x = 0f;
            for (int i = 0; i < gridX + 1; i++)
            {
                gr.DrawLine(p, x, y, xSpace * gridX, y);
                y += ySpace;
            }

            World = new bool[gridX, gridY];
            for (int i = 0; i < gridX; i++)
            {
                for (int c = 0; c < gridY; c++)
                {
                    World[i, c] = true;
                }
            }

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            RunAlgorithm();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Reset the grid and all data
            gridPanel.Refresh();
            RunAlgorithm();
        }

        private void btnStepOne_Click(object sender, EventArgs e)
        {
            // TODO Make next step in the A* algorithm and progress
            //      Horizontal and Vertical movement cost is 10
            //      Diagonal movement cost is 14
        }

        private void RunAlgorithm()
        {
            if (Int32.TryParse(tbWidth.Text, out gridX) && Int32.TryParse(tbHeight.Text, out gridY))
            {
                BuildGrid();
                setStartAndTargetLocations();
                btnStart.Enabled = false;
                btnReset.Enabled = true;
                //btnStepOne.Enabled = true;

                if (rbOwn.Checked)
                {
                    OwnImplementation.PathFinder pathFinder = new OwnImplementation.PathFinder(new ManhattenCalculator());
                    List<OwnImplementation.Node> bestPath = pathFinder.FindBestPath(pathFinderParameters);
                    ShowRoute("The algorithm should find a direct path without obstacles:", bestPath);
                }
                else
                {
                    SimpleAlgorithm.PathFinder pathFinder = new SimpleAlgorithm.PathFinder(searchParameters);
                    path = pathFinder.FindPath();
                    ShowRoute("The algorithm should find a direct path without obstacles:", path);
                }

            }
            else
            {
                // Not numbers in either the width or height textboxes
                throw new ArithmeticException("Input values for either width or height is not a number.");
            }
        }

        private void ShowRoute(string v, List<Coordinate> path)
        {
            // TODO Draw the path to the destination
            Graphics gr = gridPanel.CreateGraphics();
            Pen p = new Pen(Color.Black, 1);
            float x = 0f;
            float y = 0f;
            float xSpace = (gridPanel.Width / gridX);
            float ySpace = gridPanel.Height / gridY;
            foreach (Coordinate point in path)
            {
                x = xSpace * point.X;
                y = ySpace * point.Y;
                if (point.X == targetLocation.X && point.Y == targetLocation.Y)
                {
                    continue;
                }
                gr.FillRectangle(Brushes.Purple, x + p.Width, y + p.Width, xSpace - p.Width, ySpace - p.Width);
            }

        }

        private void ShowRoute(string v, List<OwnImplementation.Node> path)
        {
            // TODO Draw the path to the destination
            Graphics gr = gridPanel.CreateGraphics();
            Pen p = new Pen(Color.Black, 1);
            float x = 0f;
            float y = 0f;
            float xSpace = (gridPanel.Width / gridX);
            float ySpace = gridPanel.Height / gridY;
            foreach (OwnImplementation.Node n in path)
            {
                x = xSpace * n.Location.X;
                y = ySpace * n.Location.Y;
                if (n.Location.Equals(targetLocation) || n.Location.Equals(startLocation))
                {
                    continue;
                }
                gr.FillRectangle(Brushes.Purple, x + p.Width, y + p.Width, xSpace - p.Width, ySpace - p.Width);
            }

        }

        private void setStartAndTargetLocations()
        {
            startLocation = new Coordinate(rnd.Next(0, gridX), rnd.Next(0, gridY));
            targetLocation = new Coordinate(rnd.Next(0, gridX), rnd.Next(0, gridY));
            if (targetLocation.X == startLocation.X && targetLocation.Y == startLocation.Y)
            {
                targetLocation = new Coordinate(rnd.Next(0, gridX), rnd.Next(0, gridY));
            }

            //startLocation = new Coordinate(0, 1);
            //targetLocation = new Coordinate(4, 7);

            // Initializing the search parameters for the PathFinder
            this.searchParameters = new SearchParameters(startLocation, targetLocation, World);


            OwnImplementation.Node startNode = new OwnImplementation.Node(startLocation);
            OwnImplementation.Node endNode = new OwnImplementation.Node(targetLocation);
            List<OwnImplementation.Node> allNodes = new List<OwnImplementation.Node>();
            // TODO allNodes should contain the entire map!
            for (int i = 0; i < gridX; i++)
            {
                for (int c = 0; c < gridY; c++)
                {
                    Coordinate coord = new Coordinate(i, c);

                    allNodes.Add(new OwnImplementation.Node(coord));
                }
            }

            this.pathFinderParameters = new PathFinderParameters(allNodes, startNode, endNode);



            // TODO Draw the two locations on the grid
            Graphics gr = gridPanel.CreateGraphics();
            Pen p = new Pen(Color.Black, 1);
            float x = 0f;
            float y = 0f;
            float xSpace = (gridPanel.Width / gridX);
            float ySpace = gridPanel.Height / gridY;
            Coordinate tmp;
            for (int i = 0; i < gridY; i++)
            {
                for (int c = 0; c < gridX; c++)
                {
                    tmp = new Coordinate(c, i);
                    if (tmp.X == startLocation.X && tmp.Y == startLocation.Y)
                    {
                        gr.FillRectangle(Brushes.Blue, x + p.Width, y + p.Width, xSpace - p.Width, ySpace - p.Width);
                    }
                    else if (tmp.X == targetLocation.X && tmp.Y == targetLocation.Y)
                    {
                        gr.FillRectangle(Brushes.Green, x + p.Width, y + p.Width, xSpace - p.Width, ySpace - p.Width);
                    }
                    x += xSpace;
                }
                y += ySpace;
                x = 0f;
            }

        }
    }
}
