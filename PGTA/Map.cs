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
        int mult = 1;
        int small_counter = 0;
        int data_count = 0;
        DataDecoded[] all_data;
        DataDecoded[] small_data = new DataDecoded[6000];
        GMapOverlay markerOverlay;
        GMapOverlay markerOverlay2;
        System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
        double initialTime;
        System.TimeSpan timeSpan;
        int borrar = 0;
        List<string> row = new List<string>();
        DataTable dt = new DataTable();

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

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dt.Columns.Add("Sic");
            dt.Columns.Add("Sac");
            dt.Columns.Add("Service ID");
            dt.Columns.Add("Time Track Info");
            dt.Columns.Add("Latitude (WGS-84)");
            dt.Columns.Add("Longitude (WGS-84)");
            dt.Columns.Add("X (Cartesian)");
            dt.Columns.Add("Y (Cartesian)");
            dt.Columns.Add("Vx (Cartesian)");
            dt.Columns.Add("Vy (Cartesian)");
            dt.Columns.Add("ax (Cartesian)");
            dt.Columns.Add("ay (Cartesian)");
            dt.Columns.Add("Octal Mode 3A");
            dt.Columns.Add("Target Identification Status");
            dt.Columns.Add("Target ID");
            dt.Columns.Add("Track number");
            dt.Columns.Add("Measured Flight Level");
            dt.Columns.Add("Geometric Altitude (ft)");
            dt.Columns.Add("Barometric Altitude (Click to expand)");
            dt.Columns.Add("Rate of Climb/Descent (feet/minute)");
            dt.Columns.Add("Track Mode 2 Code");
            dataGridView1.DataSource = dt;

        }
        //Metodo para mover las aeronaves con cada tick del reloj
        private void timer1_Tick(object sender, EventArgs e) 
        {
            try
            {
                Bitmap plane1 = (Bitmap)Image.FromFile("img/plane.png");
                Bitmap plane = new Bitmap(plane1, new Size(plane1.Width / 12, plane1.Height / 12));

                timeSpan = watch.Elapsed;
                double time = timeSpan.TotalSeconds * mult + initialTime;

                double horas = time / 3600;
                int horas_int = (int)Math.Floor(horas);
                double min = (time - horas_int * 3600) / 60;
                int min_int = (int)Math.Floor(min);
                double sec = time - (horas_int * 3600 + min_int * 60);
                int sec_int = (int)Math.Floor(sec);
                label1.Text = horas_int.ToString() + " h " + min_int.ToString() + " min " + sec_int.ToString() + " s";
                numericUpDown2.Value = horas_int;
                numericUpDown2.Minimum = horas_int;

                //Borrar las aeronaves de las que no se tenga informacion en 20 s
                if (borrar < 20)
                {
                    borrar++;
                }
                else
                {
                    for (int i = 0; i < all_data.Length; i++)
                    {
                        if (all_data[i] != null)
                        {
                            if (time - all_data[i].Time_track_info > 30)
                            {
                                for (int p = 0; p < markerOverlay.Markers.Count(); p++)
                                {
                                    if (all_data[i].Target_id_245 != null)
                                    {
                                        if (markerOverlay.Markers[p].Tag.ToString() == all_data[i].Target_id_245)
                                        {
                                            markerOverlay.Markers.RemoveAt(p);
                                        }
                                    }
                                    else if (markerOverlay.Markers[p].Tag.ToString() == all_data[i].Octal_mode3A.ToString())
                                    {
                                        markerOverlay.Markers.RemoveAt(p);
                                    }
                                }
                            }
                        }
                    }
                    borrar = 0;
                }
                //Si el ultimo valor del time track de la particion de la tabla generada es menor que el tiempo en el que estamos genera otra particion
                while (small_data[small_data.Length - 1].Time_track_info < time)
                {
                    Load_Small_Data();
                }
                //Si va a pintar un avion que ya estaba pintado borra la posicion anterior
                while (time >= small_data[small_counter].Time_track_info)
                {
                    for (int i = 0; i < markerOverlay.Markers.Count(); i++)
                    {
                        if (small_data[small_counter].Target_id_245 != null)
                        {
                            if (markerOverlay.Markers[i].Tag.ToString() == small_data[small_counter].Target_id_245)
                            {
                                markerOverlay.Markers.RemoveAt(i);
                            }
                        }
                        else if (markerOverlay.Markers[i].Tag.ToString() == small_data[small_counter].Octal_mode3A.ToString())
                        {
                            markerOverlay.Markers.RemoveAt(i);
                        }
                    }
                    //Genera los markers
                    GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(small_data[small_counter].Latitude, small_data[small_counter].Longitude), RotateImg(plane, small_data[small_counter].Mag_heading));
                    //Si el avión tiene valor en el target id se le asigna al valor Tag del marker, si no se le asigna el Octal.
                    if (small_data[small_counter].Target_id_245 != null)
                    {
                        marker.Tag = small_data[small_counter].Target_id_245;
                    }
                    else
                    {
                        marker.Tag = small_data[small_counter].Octal_mode3A;
                    }
                    markerOverlay.Markers.Add(marker); //Pinta los markers
                    small_counter++;
                }

                gMapControl1.Overlays.Add(markerOverlay);
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        //Hace una copia de la tabla de 6000 posiciones para poder procesar los datos mas eficientemente
        private void Load_Small_Data()
        {
            try
            {
                small_counter = 0;
                int initial_count = data_count;
                for (int i = 0; data_count < initial_count + 6000; i++)
                {
                    small_data[i] = all_data[data_count];
                    data_count++;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        //Cambia la velocidad a x1
        private void button1_Click(object sender, EventArgs e)
        {
            mult = 1;
        }
        //Cambia la velocidad a x10
        private void button2_Click(object sender, EventArgs e)
        {
            mult = 10;
        }
        //Cambia la velocidad a x20
        private void button3_Click(object sender, EventArgs e)
        {
            mult = 20;
        }

        //Gira la foto segun el heading del avion
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

        //Metodo que se activa cuando se hace click en un avión
        private void gMapControl1_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            try
            {
                dt.Clear();
                timer1.Stop();
                Bitmap plane1 = (Bitmap)Image.FromFile("img/plane2.png");
                Bitmap plane = new Bitmap(plane1, new Size(plane1.Width / 12, plane1.Height / 12));
                bool encontrado = false;
                for (int i = 0; i < small_data.Length; i++)
                {

                    if (small_data[small_counter].Target_id_245 != null)
                    {
                        if (small_data[i] != null && small_data[i].Target_id_245 == item.Tag.ToString())
                        {
                            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(small_data[i].Latitude, small_data[i].Longitude), RotateImg(plane, small_data[i].Mag_heading));
                            marker.Tag = small_data[i].Target_id_245;
                            markerOverlay2.Markers.Add(marker);
                        }
                    }
                    else if (small_data[i] != null && small_data[i].Octal_mode3A.ToString() == item.Tag.ToString())
                    {
                        GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(small_data[i].Latitude, small_data[i].Longitude), RotateImg(plane, small_data[i].Mag_heading));
                        marker.Tag = small_data[i].Octal_mode3A;
                        markerOverlay2.Markers.Add(marker);
                    }
                }
                
                for (int p = 0; p<small_data.Length && !encontrado; p++)
                {
                    if (item.Position.Lat == small_data[p].Latitude && item.Position.Lng == small_data[p].Longitude)
                    {
                        encontrado = true;
                        //Rellenar tabla
                        row.Add(small_data[p].Sic.ToString());
                        row.Add(small_data[p].Sac.ToString()); ;
                        row.Add(small_data[p].Service_Id.ToString());
                        int hor, min, seg;
                        hor = Convert.ToInt32(small_data[p].Time_track_info / 3600);
                        min = Convert.ToInt32((small_data[p].Time_track_info - hor * 3600) / 60);
                        seg = Convert.ToInt32(small_data[p].Time_track_info - (hor * 3600 + min * 60));
                        string shor, smin, sseg;
                        if (hor <= 9)
                        {
                            shor = "0" + hor.ToString();
                        }
                        else
                        {
                            shor = hor.ToString();
                        }
                        if (min <= 9)
                        {
                            smin = "0" + min.ToString();
                        }
                        else
                        {
                            smin = min.ToString();
                        }
                        if (seg <= 9)
                        {
                            sseg = "0" + seg.ToString();
                        }
                        else
                        {
                            sseg = seg.ToString();
                        }
                        string time = shor + ":" + smin + ":" + sseg;
                        row.Add(time);
                        double lat_red = Math.Round(small_data[p].Latitude, 2);
                        row.Add(lat_red.ToString() + " º");
                        double long_red = Math.Round(small_data[p].Longitude, 2);
                        row.Add(long_red.ToString() + " º");
                        row.Add(small_data[p].X.ToString() + " m");
                        row.Add(small_data[p].Y.ToString() + " m");
                        row.Add(small_data[p].Vx.ToString() + " m/s");
                        row.Add(small_data[p].Vy.ToString() + " m/s");
                        if (small_data[p].Ax != 0)
                        {
                            row.Add(small_data[p].Ax.ToString());
                        }
                        else
                        {
                            row.Add("-");
                        }
                        if (small_data[p].Ay != 0)
                        {
                            row.Add(small_data[p].Ay.ToString());
                        }
                        else
                        {
                            row.Add("-");
                        }
                        row.Add(small_data[p].Octal_mode3A.ToString());
                        if (small_data[p].Target_id_status != null)
                        {
                            row.Add(small_data[p].Target_id_status.ToString());
                        }
                        else
                        {
                            row.Add("-");
                        }
                        if (small_data[p].Target_id_245 != null)
                        {
                            row.Add(small_data[p].Target_id_245.ToString());
                        }
                        else
                        {
                            row.Add("-");
                        }
                        row.Add(small_data[p].Track_num.ToString());
                        row.Add(small_data[p].FL.ToString());
                        row.Add(small_data[p].TGA.ToString());
                        string barometric_alt;
                        if (small_data[p].CorrectionQNH)
                        {
                            barometric_alt = "QNH correction" + "\n" + "BA = " + small_data[p].TBA.ToString() + " ft";
                        }
                        else
                        {
                            barometric_alt = "No QNH correction" + "\n" + "BA = " + small_data[p].TBA.ToString() + " ft";
                        }
                        row.Add(barometric_alt);
                        row.Add(small_data[p].Rate.ToString());
                        string Octal_mode2A = "";
                        if (small_data[p].Octal_mode2A == 0)
                        {
                            Octal_mode2A = "-";
                        }
                        else
                        {
                            Octal_mode2A = small_data[p].Octal_mode2A.ToString();
                        }
                        row.Add(Octal_mode2A);
                    }
                }
                
                gMapControl1.Overlays.Add(markerOverlay2);
                DataRow row2 = dt.NewRow();
                row2.ItemArray = row.ToArray();
                dt.Rows.Add(row2);
                dataGridView1.DataSource = dt;
                row.Clear();

                timer1.Start();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
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

        //Boton para eliminar las trazas y la tabla
        private void button5_Click(object sender, EventArgs e)
        {
            markerOverlay2.Markers.Clear();
            dt.Clear();
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
            try
            {
                timer1.Stop();
                markerOverlay2.Markers.Clear();
                markerOverlay.Markers.Clear();
                initialTime = (double)numericUpDown2.Value * 3600;
                watch.Restart();
                timer1.Start();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        //Boton restart
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();
                markerOverlay2.Markers.Clear();
                markerOverlay.Markers.Clear();
                initialTime = all_data[0].Time_track_info - 2;
                watch.Restart();
                data_count = 0;
                Load_Small_Data();
                timer1.Start();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

        }
        //Función que se activa cuando cambia el tamaño del Form
        private void Map_SizeChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            gMapControl1.Width = Screen.FromControl(this).Bounds.Width - 70;
            gMapControl1.Height = Screen.FromControl(this).Bounds.Height - 70;
            timer1.Start();
        }
    }
}




