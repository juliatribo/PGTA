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
        int small_counter = 0;
        int data_count = 0;
        DataDecoded[] all_data;
        DataDecoded[] small_data = new DataDecoded[6000];
        GMapOverlay markerOverlay;
        GMapOverlay markerOverlay2;
        System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
        double initialTime;
        System.TimeSpan timeSpan;
        bool change = false;

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
            
            gMapControl1.Width = Screen.FromControl(this).Bounds.Width-40;
            gMapControl1.Height = Screen.FromControl(this).Bounds.Height-40;
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
            initialTime = all_data[0].Time_track_info - 2; 

            double horas = initialTime / 3600;
            int horas_int = (int)Math.Floor(horas);

            double min = (initialTime - horas_int * 3600) / 60;
            int min_int = (int)Math.Floor(min);

            double sec = initialTime - (horas_int * 3600 + min_int * 60);
            int sec_int = (int)Math.Floor(sec);

            label1.Text = horas_int.ToString() + " h" + min_int.ToString() + " min" + sec_int.ToString() + " s";

            label3.Text = "Target ID or Mode3A";
            Load_Small_Data();

        }

        private void timer1_Tick(object sender, EventArgs e) 
        {
            Bitmap plane1 = (Bitmap)Image.FromFile("img/plane.png");
            Bitmap plane = new Bitmap(plane1, new Size(plane1.Width / 12, plane1.Height / 12));

            timeSpan = watch.Elapsed;
            double time = timeSpan.TotalSeconds + initialTime;

            double horas = time / 3600;
            int horas_int = (int)Math.Floor(horas);
            double min = (time - horas_int * 3600) / 60;
            int min_int = (int)Math.Floor(min);
            double sec = time - (horas_int * 3600 + min_int * 60);
            int sec_int = (int)Math.Floor(sec);
            label1.Text = horas_int.ToString() + " h " + min_int.ToString() + " min " + sec_int.ToString() + " s";

            while (small_data[small_data.Length -1].Time_track_info < time)
            {
                Load_Small_Data();
            }

            while (time >= small_data[small_counter].Time_track_info)
            {
                for (int i = 0; i < markerOverlay.Markers.Count(); i++)
                {
                    if(small_data[small_counter].Target_id_245 != null)
                    {
                        if(markerOverlay.Markers[i].Tag.ToString() == small_data[small_counter].Target_id_245)
                        {
                            markerOverlay.Markers.RemoveAt(i);
                        }
                    }
                    else if (markerOverlay.Markers[i].Tag.ToString() == small_data[small_counter].Octal_mode3A.ToString())
                    {
                        markerOverlay.Markers.RemoveAt(i);
                    }
                }

                GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(small_data[small_counter].Latitude, small_data[small_counter].Longitude), RotateImg(plane, small_data[small_counter].Mag_heading));
                if (small_data[small_counter].Target_id_245 != null)
                {
                    marker.Tag = small_data[small_counter].Target_id_245;
                }
                else
                {
                    marker.Tag = small_data[small_counter].Octal_mode3A;
                }
                markerOverlay.Markers.Add(marker);
                //counter++;
                small_counter++;
            }

            gMapControl1.Overlays.Add(markerOverlay);         
        }
        private void Load_Small_Data()
        {
            small_counter = 0;
            int initial_count = data_count;
            for (int i = 0; data_count < initial_count + 6000; i++)
            {
                small_data[i] = all_data[data_count];
                data_count++;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Interval = 100;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Interval = 50;
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


            for (int i = 0; i < small_data.Length; i++)
            {
                if (small_data[small_counter].Target_id_245 != null)
                {
                    if (small_data[i] != null && small_data[i].Target_id_245 == item.Tag.ToString())
                    {
                        GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(small_data[i].Latitude, small_data[i].Longitude), RotateImg(plane, small_data[i].Mag_heading));
                        marker.Tag = small_data[i].Target_id_245;
                        markerOverlay2.Markers.Add(marker);
                        label3.Text = small_data[i].Target_id_245.ToString();
                        
                    }
                }
                else if (small_data[i] != null && small_data[i].Octal_mode3A == Convert.ToInt32(item.Tag))
                {
                    GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(small_data[i].Latitude, small_data[i].Longitude), RotateImg(plane, small_data[i].Mag_heading));
                    marker.Tag = small_data[i].Octal_mode3A;
                    markerOverlay2.Markers.Add(marker);
                    label3.Text = small_data[i].Octal_mode3A.ToString();
                }

            }

            gMapControl1.Overlays.Add(markerOverlay2);
        }

        //Boton para iniciar o parar la simulación
        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Stop")
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

        //Boton para eliminar las trazas
        private void button5_Click(object sender, EventArgs e)
        {
            markerOverlay2.Markers.Clear();
        }

        //Boton para exportar a kml las posiciones de los aviones
        private void button6_Click(object sender, EventArgs e)
        {
            var document = new Document();
            Kml kml = new Kml();
            Placemark placemarks;
            Point Punto_gps;

            for (int i = 0; i < markerOverlay.Markers.Count(); i++)
            {
                Style plane = new Style();
                plane.Id = "planeIcon";
                plane.Icon = new IconStyle();
                plane.Icon.Icon = new IconStyle.IconLink(new Uri("http://maps.google.com/mapfiles/kml/shapes/airports.png"));
                document.AddStyle(plane);
                Punto_gps = new Point();
                Punto_gps.Coordinate = new SharpKml.Base.Vector(markerOverlay.Markers[i].Position.Lat, markerOverlay.Markers[i].Position.Lng);
                placemarks = new Placemark();
                placemarks.Name = markerOverlay.Markers[i].Tag.ToString();
                placemarks.Geometry = Punto_gps;
                placemarks.StyleUrl = new Uri("#planeIcon", UriKind.Relative);
                document.AddFeature(placemarks);
            }
            SharpKml.Engine.KmlFile kmlFile = SharpKml.Engine.KmlFile.Create(document, true);


            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "KML-File | *.kml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                kmlFile.Save(System.IO.File.OpenWrite(saveFileDialog.FileName));
            }
        }
    

        //Boton para iniciar la simulacion desde una hora determinada
        private void button7_Click(object sender, EventArgs e)
        {
            markerOverlay2.Markers.Clear();
            markerOverlay.Markers.Clear();
            initialTime = (double)numericUpDown2.Value * 3600;
            watch.Restart();
        }

        //Boton restart
        private void button8_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            markerOverlay2.Markers.Clear();
            markerOverlay.Markers.Clear();
            initialTime = all_data[0].Time_track_info - 2;
            watch.Restart();
            data_count = 0;
            counter = 0;
            Load_Small_Data();
            timer1.Start();
            
        }

        private void Map_SizeChanged(object sender, EventArgs e)
        {
            gMapControl1.Width = Screen.FromControl(this).Bounds.Width-70;
            gMapControl1.Height = Screen.FromControl(this).Bounds.Height-70;
        }
    }
}



