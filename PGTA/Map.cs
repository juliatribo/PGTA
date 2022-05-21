using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Numerics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Drawing.Drawing2D;
using SharpKml.Dom;
using Point = SharpKml.Dom.Point;
using Placemark = SharpKml.Dom.Placemark;
using SharpKml.Base;
using System.Xml.Linq;

namespace PGTA
{
    public partial class Map : Form
    {
        int counter = 0;
        DataDecoded[] all_data;
        GMapOverlay markerOverlay;
        GMapOverlay markerOverlay2;
        System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
        double time;

        public Map()
        {
            InitializeComponent();
        }
        
        public void setData(DataDecoded[] all_data)
        {
            this.all_data = all_data;
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.AutoScroll = true;
            gMapControl1.MinZoom = 5;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 12;
            gMapControl1.Position = new PointLatLng(all_data[0].Latitude, all_data[0].Longitude);
            timer1.Start();
            watch.Start();

            markerOverlay = new GMapOverlay("markers");
            markerOverlay2 = new GMapOverlay("traces");


        }

        private void Map_Load(object sender, EventArgs e)
        {
            numericUpDown2.Value = 9;
            time = all_data[0].Time_track_info - 2; 

            double horas = time / 3600;
            int horas_int = (int)Math.Floor(horas);


            double min = (time - horas_int * 3600) / 60;
            int min_int = (int)Math.Floor(min);

            double sec = time - (horas_int * 3600 + min_int * 60);
            int sec_int = (int)Math.Floor(sec);

            label1.Text = horas_int.ToString() + " h" + min_int.ToString() + " min" + sec_int.ToString() + " s";

            label3.Text = "Target ID or Mode3A";

        }

        private void timer1_Tick(object sender, EventArgs e) 
        {
            Bitmap plane1 = (Bitmap)Image.FromFile("img/plane.png");
            Bitmap plane = new Bitmap(plane1, new Size(plane1.Width / 12, plane1.Height / 12));

            //System.TimeSpan timeSpan = watch.Elapsed;
            //double interval = timeSpan.TotalSeconds;

            time = time + timer1.Interval / 1000;
            //time = time + interval;
            double horas = time / 3600;
            int horas_int = (int)Math.Floor(horas);


            double min = (time - horas_int * 3600) / 60;
            int min_int = (int)Math.Floor(min);

            double sec = time - (horas_int * 3600 + min_int * 60);
            int sec_int = (int)Math.Floor(sec);

            label1.Text = horas_int.ToString() + " h " + min_int.ToString() + " min " + sec_int.ToString() + " s";


            while (time >= all_data[counter].Time_track_info)
            {
                for (int i = 0; i < markerOverlay.Markers.Count(); i++)
                {
                    if (Convert.ToInt32(markerOverlay.Markers[i].Tag) == all_data[counter].Octal_mode3A)
                    {
                        markerOverlay.Markers.RemoveAt(i);
                    }
                }

                GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(all_data[counter].Latitude, all_data[counter].Longitude), RotateImg(plane, all_data[counter].Mag_heading));
                marker.Tag = all_data[counter].Octal_mode3A;
                markerOverlay.Markers.Add(marker);
                counter++;
            }

            gMapControl1.Overlays.Add(markerOverlay);
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Interval = 10000;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Interval = 20000;
        }

        public Bitmap RotateImg(Bitmap bmpimage, double ang)
        {
            float angle = (float)ang;
            int w = bmpimage.Width;
            int h = bmpimage.Height;
            System.Drawing.Imaging.PixelFormat pf;
            pf = bmpimage.PixelFormat;
            Bitmap tempImg = new Bitmap(w, h, pf);
            Graphics g = Graphics.FromImage(tempImg);
            g.DrawImageUnscaled(bmpimage, 1, 1);
            g.Dispose();
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new RectangleF(0.0F, 0.0F, w, h));
            Matrix mtrx = new Matrix();

            mtrx.Rotate(angle);
            RectangleF rct = path.GetBounds(mtrx);
            Bitmap newImg = new Bitmap(Convert.ToInt32(rct.Width), Convert.ToInt32(rct.Height), pf);
            g = Graphics.FromImage(newImg);
            g.TranslateTransform(-rct.X, -rct.Y);
            g.RotateTransform(angle);
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.DrawImageUnscaled(tempImg, 0, 0);
            g.Dispose();
            tempImg.Dispose();
            return newImg;
        }

        private void gMapControl1_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            Bitmap plane1 = (Bitmap)Image.FromFile("img/plane2.png");
            Bitmap plane = new Bitmap(plane1, new Size(plane1.Width / 12, plane1.Height / 12));


            for (int i = 0; i < all_data.Length; i++)
            {
                if (all_data[i] != null && all_data[i].Octal_mode3A == Convert.ToInt32(item.Tag))
                {
                    GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(all_data[i].Latitude, all_data[i].Longitude), RotateImg(plane, all_data[i].Mag_heading));
                    marker.Tag = all_data[i].Octal_mode3A;
                    markerOverlay2.Markers.Add(marker);
                    if (all_data[i].Target_id_245 != null)
                    {
                        label3.Text = all_data[i].Target_id_245.ToString();
                    }
                    else
                    {
                        label3.Text = all_data[i].Octal_mode3A.ToString();
                    }
                }
            }
            

            gMapControl1.Overlays.Add(markerOverlay2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(button4.Text == "Stop")
            {
                timer1.Stop();
                button4.Text = "Start";
            }
            else
            {
                timer1.Start();
                button4.Text = "Stop";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            markerOverlay2.Markers.Clear();
            label3.Text = "Target ID or Mode3A";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var document = new Document();
            Kml kml = new Kml();
            Placemark placemarks;
            Point Punto_gps;
            Style plane = new Style();
            plane.Id = "planeIcon";
            plane.Icon = new IconStyle();
            plane.Icon.Icon = new IconStyle.IconLink(new Uri("http://maps.google.com/mapfiles/kml/shapes/airports.png"));
            document.AddStyle(plane);


            for (int i = 0; i < markerOverlay.Markers.Count(); i++)
            {
                Punto_gps = new Point();
                Punto_gps.Coordinate = new SharpKml.Base.Vector(all_data[i].Latitude, all_data[i].Longitude);
                placemarks = new Placemark();
                placemarks.Name = markerOverlay.Markers[i].Tag.ToString();
                placemarks.Geometry = Punto_gps;
                placemarks.StyleUrl = new Uri("#planeIcon", UriKind.Relative); ;
                document.AddFeature(placemarks);;
                
            }
            SharpKml.Engine.KmlFile kmlFile = SharpKml.Engine.KmlFile.Create(document, true);


            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "KML-File | *.kml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                kmlFile.Save(System.IO.File.OpenWrite(saveFileDialog.FileName));
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            markerOverlay2.Markers.Clear();
            markerOverlay.Markers.Clear();

            time = (double)numericUpDown2.Value * 3600;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            markerOverlay2.Markers.Clear();
            markerOverlay.Markers.Clear();
            time = all_data[0].Time_track_info - 2;
        }
    }
}
