using SetTheGame.Model;
using SetTheGame.TutorialPages;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SetTheGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UCCard : Grid
    {
        SKSurface surface;
        SKCanvas canvas;
        int width;
        int height;

        public Card card { get; set; }
        private Grid board;
        public int id { get; set; }

        // Shapes Path 
        SKPath wavePath = new SKPath();
        SKPath ovaPath = new SKPath();
        SKPath diamonPath = new SKPath();
        SKPath waveFillPath = new SKPath();
        SKPath ovaFillPath = new SKPath();
        SKPath diamonFillPath = new SKPath();

        public UCCard(Grid grid, Card card, int id) : this(card)
        {
            this.board = (Board)grid;
            this.id = id;
            // Touch Recognizer
            CardGrid.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => {
                    Debug.WriteLine("UCCardTapped : " + card.ToString());
                    ((Board)board).CardTapped(this.id);
                }),
                NumberOfTapsRequired = 1
            }); 
        }

        public UCCard(Card card)
        {
            InitializeComponent();
            this.card = card;
            CardGrid.BackgroundColor = Xamarin.Forms.Color.White;

            //Wave
            wavePath.MoveTo(-100, 30);
            wavePath.ArcTo(50, 50, 0, SKPathArcSize.Small, SKPathDirection.Clockwise, 30, -10);
            wavePath.ArcTo(50, 100, 0, SKPathArcSize.Small, SKPathDirection.CounterClockwise, 100, -30);
            wavePath.ArcTo(50, 50, 0, SKPathArcSize.Small, SKPathDirection.Clockwise, -30, 10);
            wavePath.ArcTo(50, 100, 0, SKPathArcSize.Small, SKPathDirection.CounterClockwise, -100, 30);
            wavePath.Close();

            //Filling wave
            waveFillPath.MoveTo(-100, 30);
            waveFillPath.LineTo(-68, -50);
            waveFillPath.MoveTo(-68, -10);
            waveFillPath.LineTo(-45, -58);
            waveFillPath.MoveTo(-45, -7);
            waveFillPath.LineTo(-23, -57);
            waveFillPath.MoveTo(-28, 15);
            waveFillPath.LineTo(0, -48);
            waveFillPath.MoveTo(-10, 41);
            waveFillPath.LineTo(20, -28);
            waveFillPath.MoveTo(15, 55);
            waveFillPath.LineTo(40, 2);
            waveFillPath.MoveTo(40, 58);
            waveFillPath.LineTo(63, 10);
            waveFillPath.MoveTo(65, 50);
            waveFillPath.LineTo(100, -30);

            //oval
            ovaPath.MoveTo(45, -50);
            ovaPath.ArcTo(40, 30, 0, SKPathArcSize.Small, SKPathDirection.Clockwise, 45, 50);
            ovaPath.LineTo(-45, 50);
            ovaPath.ArcTo(40, 30, 0, SKPathArcSize.Small, SKPathDirection.Clockwise, -45, -50);
            ovaPath.Close();

            //filling oval
            ovaFillPath.MoveTo(-100, 29);
            ovaFillPath.LineTo(-65, -47);
            ovaFillPath.MoveTo(-78, 43);
            ovaFillPath.LineTo(-35, -50);
            ovaFillPath.MoveTo(-50, 50);
            ovaFillPath.LineTo(-5, -50);
            ovaFillPath.MoveTo(-20, 50);
            ovaFillPath.LineTo(25, -50);
            ovaFillPath.MoveTo(10, 50);
            ovaFillPath.LineTo(55, -50);
            ovaFillPath.MoveTo(40, 50);
            ovaFillPath.LineTo(78, -43);
            ovaFillPath.MoveTo(68, 46);
            ovaFillPath.LineTo(100, -27);

            //diamond
            diamonPath.MoveTo(-130, 0);
            diamonPath.LineTo(0, 65);
            diamonPath.LineTo(130, 0);
            diamonPath.LineTo(0, -65);
            diamonPath.Close();

            //filling diamon
            diamonFillPath.MoveTo(-112, 8);
            diamonFillPath.LineTo(-105, -12);
            diamonFillPath.MoveTo(-95, 17);
            diamonFillPath.LineTo(-80, -25);
            diamonFillPath.MoveTo(-77, 25);
            diamonFillPath.LineTo(-57, -35);
            diamonFillPath.MoveTo(-58, 36);
            diamonFillPath.LineTo(-30, -50);
            diamonFillPath.MoveTo(-37, 45);
            diamonFillPath.LineTo(-4, -63);
            diamonFillPath.MoveTo(-15, 57);
            diamonFillPath.LineTo(18, -55);
            diamonFillPath.MoveTo(10, 60);
            diamonFillPath.LineTo(42, -42);
            diamonFillPath.MoveTo(38, 46);
            diamonFillPath.LineTo(63, -33);
            diamonFillPath.MoveTo(65, 32);
            diamonFillPath.LineTo(85, -22);
            diamonFillPath.MoveTo(90, 20);
            diamonFillPath.LineTo(103, -12);
            diamonFillPath.MoveTo(110, 10);
            diamonFillPath.LineTo(117, -5);
        }

        public void RightAnswerHighlight()
        {
            CardGrid.BackgroundColor = Xamarin.Forms.Color.PaleGreen;
        }

        public void SetTutorialCard(TutorialBoard tutoBoard, int identifier)
        {
            this.id = identifier;
            CardGrid.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => {
                    Debug.WriteLine("UCCardTapped : " + card.ToString());
                    tutoBoard.CardTapped(this.id);
                }),
                NumberOfTapsRequired = 1
            });
        }

        public void DisableClick()
        {
            CardGrid.GestureRecognizers.Clear();
        }

        private void canvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            surface = e.Surface;
            canvas = surface.Canvas;
            width = e.Info.Width;
            height = e.Info.Height;
                
            Draw();
        }       

        public void ReDraw()
        {
            canvasView.InvalidateSurface();
        }

        public void Draw()
        {
            canvas.Clear();

            SKPath path = new SKPath();
            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = SKColors.White
            };

            switch (card.Shape)
            {
                case Shapes.Oval:
                    path = ovaPath;
                    break;
                case Shapes.Diamond:
                    path = diamonPath;
                    break;
                case Shapes.Wave:
                    path = wavePath;
                    break;
            }

            switch (card.Fill)
            {
                case Fills.Empty:
                    paint.Style = SKPaintStyle.Stroke;
                    paint.StrokeWidth = 10;
                    break;
                case Fills.Filled:
                    paint.Style = SKPaintStyle.Fill;
                    break;
                case Fills.Hatched:
                    paint.Style = SKPaintStyle.Stroke;
                    paint.StrokeWidth = 10;
                    break;
            }

            paint.Color = new SKColor((Byte)card.Color.Red, (Byte)card.Color.Green, (Byte)card.Color.Blue);
            canvas.Translate(width / 2, height / 2);
            canvas.Scale(Math.Min(width / 210f, height / 520f));

            switch (card.Number)
            {
                case 1:
                    createForm(path, paint);
                    break;
                case 2:
                    canvas.Translate(0, -100);
                    for (int i = 0; i < 2; i++)
                    {
                        canvas.Save();

                        canvas.Translate(0, -300 * i + 150);
                        createForm(path, paint);
                    }
                    break;
                case 3:
                    canvas.Translate(0, 300);
                    for (int i = 0; i < 3; i++)
                    {
                        canvas.Save();
                        canvas.Translate(0, -150);
                        createForm(path, paint);
                    }
                    break;
            }
        }

        private void createForm(SKPath path, SKPaint paint)
        {
            SKPath fillPath = new SKPath();
            canvas.Save();
            canvas.DrawPath(path, paint);
            if (card.Fill == Fills.Hatched)
            {
                switch (card.Shape)
                {
                    case Shapes.Oval:
                        fillPath = ovaFillPath;
                        break;
                    case Shapes.Diamond:
                        fillPath = diamonFillPath;
                        break;
                    case Shapes.Wave:
                        fillPath = waveFillPath;
                        break;
                }
                canvas.DrawPath(fillPath, paint);
            }
            canvas.Restore();
        }

        public void Select()
        {
            //Ajouter une bordure à la carte pour signaler qu'elle a été selectionnée
            Debug.WriteLine("Card selected - Borders shown");
            CardGrid.BackgroundColor = Xamarin.Forms.Color.FromRgb(210, 210, 210);
        }

        public void Deselect()
        {
            //Enlever la bordure pour signaler qu'elle n'est pas selectionnée
            Debug.WriteLine("Card deselected - Borders unshown");
            CardGrid.BackgroundColor = Xamarin.Forms.Color.White;
        }

        public void Highlight()
        {
            Debug.WriteLine("Card highlighted");
            CardGrid.BackgroundColor = Xamarin.Forms.Color.LightGoldenrodYellow;
        }
    }
}