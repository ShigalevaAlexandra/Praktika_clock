using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praktika_clock
{
    public partial class Clock : Form
    {
        //объявление глобальных переменных
        int center_x = 175,       //центр циферблата
            center_y = 175,

            second_arrow = 100,   //длина секундной стрелки
            minut_arrow = 90,     //длина минутной стрелки
            hour_arrow = 75;      //длина часовой стрелки

        Timer timer_clock = new Timer();    //создаем таймер

        public Clock()
        {
            InitializeComponent();

            //настройка прозрачности окна
            this.BackColor = Color.MidnightBlue;
            this.TransparencyKey = this.BackColor;
        }

        //Функция запуска таймера
        private void Clock_Load(object sender, EventArgs e)
        {
            timer_clock.Interval = 1000;
            timer_clock.Tick += new EventHandler(this.timer_clock_Tick);
            timer_clock.Start();
        }

        //Функция получения координат конца секундной и минутной стрелок
        private int[] Get_arrow_sm_coordination(int amount_second /*кол-во сек*/, int length_arrow /*длина стрелки*/)
        {
            int[] arrow_coord = new int[2];
            amount_second *= 6;   //1 сек - 6 градусов (360/60)

            //определение в какой четверти окружности находится конец стрелки
            if (amount_second >= 0 && amount_second <= 180)
            {
                arrow_coord[0] = center_x + (int)(length_arrow * Math.Sin(Math.PI * amount_second / 180));
                arrow_coord[1] = center_y - (int)(length_arrow * Math.Cos(Math.PI * amount_second / 180));
            }
            else
            {
                arrow_coord[0] = center_x - (int)(length_arrow * -Math.Sin(Math.PI * amount_second / 180));
                arrow_coord[1] = center_y - (int)(length_arrow * Math.Cos(Math.PI * amount_second / 180));
            }

            return arrow_coord;
        }

        //Функция получения координат конца часовой стрелки
        private int[] Get_arrow_h_coordination(int amount_minut /*кол-во мин*/, 
            int amount_hour /*кол-во мин*/, int length_arrow /*длина стрелки*/)
        {
            int[] arrow_coord = new int[2];
            int amount_time = (int)((length_arrow * 30) + (amount_minut * 0.5));  //1 час - 30 градусов, 1 минута - 0.5 градусов

            //определение в какой четверти окружности находится конец стрелки
            if (amount_time >= 0 && amount_time <= 180)
            {
                arrow_coord[0] = center_x + (int)(length_arrow * Math.Sin(Math.PI * amount_time / 180));
                arrow_coord[1] = center_y - (int)(length_arrow * Math.Cos(Math.PI * amount_time / 180));
            }
            else
            {
                arrow_coord[0] = center_x - (int)(length_arrow * -Math.Sin(Math.PI * amount_time / 180));
                arrow_coord[1] = center_y - (int)(length_arrow * Math.Cos(Math.PI * amount_time / 180));
            }

            return arrow_coord;
        }

        //Функция отрисовки стрелок на циферблате
        private void timer_clock_Tick(object sender, EventArgs e)
        {
            //считываем системное время
            int amount_second = DateTime.Now.Second;
            int amount_minut = DateTime.Now.Minute;
            int amount_hour = DateTime.Now.Hour;

            int[] arrow_coord = new int[2];

            Graphics graph = pictureBox_clock.CreateGraphics();

            //Стираем предыдущее положения секундной стрелки
            arrow_coord = Get_arrow_sm_coordination(amount_second, second_arrow + 4);
            graph.DrawLine(new Pen(Color.White, 45f), new Point(center_x, center_y), new Point(arrow_coord[0], arrow_coord[1]));

            // Стираем предыдущее положение минутной стрелки
            arrow_coord = Get_arrow_sm_coordination(amount_minut, minut_arrow + 4);
            graph.DrawLine(new Pen(Color.White, 40f), new Point(center_x, center_y), new Point(arrow_coord[0], arrow_coord[1]));

            // Стираем предыдущее положение часовой стрелки
            arrow_coord = Get_arrow_h_coordination(amount_hour % 12, amount_minut, hour_arrow + 4);
            graph.DrawLine(new Pen(Color.White, 20f), new Point(center_x, center_y), new Point(arrow_coord[0], arrow_coord[1]));

            /*----------------------------------------------------------------------------------------------------------------------*/

            //Отрисовка часовой стрелки
            arrow_coord = Get_arrow_h_coordination(amount_hour % 12, amount_minut, hour_arrow);
            graph.DrawLine(new Pen(Color.Gray, 4f), new Point(center_x, center_y), new Point(arrow_coord[0], arrow_coord[1]));

            // Отрисовка минутной стрелки
            arrow_coord = Get_arrow_sm_coordination(amount_minut, minut_arrow);
            graph.DrawLine(new Pen(Color.Black, 2f), new Point(center_x, center_y), new Point(arrow_coord[0], arrow_coord[1]));

            // Отрисовка секундной стрелки.
            arrow_coord = Get_arrow_sm_coordination(amount_second, second_arrow);
            graph.DrawLine(new Pen(Color.DarkOrange, 2f), new Point(center_x, center_y), new Point(arrow_coord[0], arrow_coord[1]));  

        }

        //Закрытие рабочего окна
        private void pictureBox_clock_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
