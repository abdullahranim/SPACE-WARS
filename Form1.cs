using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace SPACE_WARS
{
    public partial class Form1 : Form
    {

        WindowsMediaPlayer gamemedia;
        WindowsMediaPlayer shootmedia;
        WindowsMediaPlayer explosion;
        WindowsMediaPlayer damage;

        bool moveUp, moveDown, moveLeft, moveRight, space, isPressed, pause, GameIsOver;
        int starspeed, playerspeed, score, enemySpeed, enemiesBulletSpeed, Healthbar;

        PictureBox[] stars, enemies,EnemiesBullets;
        PictureBox bullet;

        Random rnd;

        public Form1()
        {
            InitializeComponent();
        }

        private void form1_Load(object sender, EventArgs e)
        {

            //creat stars in the background
            starsBackground();
            //player speed
            playerspeed = 5;
            //sound effects
            makeMedia();
            //creat enemies
            makeEnemies();
            //creat enemies bullets;
            MakeEnemiesBullets();
           
            pause = false;
            GameIsOver = false;
            Healthbar = 3;
            score = 0;

        }
        //bullets animation
        private void shoot_timer1_Tick(object sender, EventArgs e)
        {
            //for animated player bullets
            foreach (Control y in this.Controls)
            {    
                
                if (y is PictureBox && y.Tag == "bullet")
                {

                    y.Top -= 20;
                    collisonOfBullets();

                    if (((PictureBox)y).Top < this.Height - 400)
                    {
                        this.Controls.Remove(y);
                    }
                }
            }
            //for animated enemybullets
            for (int i = 0; i < EnemiesBullets.Length; i++)
            {
                if (EnemiesBullets[i].Top < this.Height)
                {
                    EnemiesBullets[i].Visible = true;
                    EnemiesBullets[i].Top += enemiesBulletSpeed;

                }
                else
                {
                    EnemiesBullets[i].Visible = false;
                    int x = rnd.Next(0, 11);
                    EnemiesBullets[i].Location = new Point(enemies[x].Location.X + 20, enemies[x].Location.Y + 30);
                }
            }
        }
        //animated enemies
        private void enemies_timer_Tick(object sender, EventArgs e)
        {

            moveEnemies(enemies, enemySpeed);

        }
        // to replay
        private void replaybtn_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            form1_Load(e, e);

        }
        //exit btn
        private void exitbtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        //animated stars
        private void starstimer1_Tick(object sender, EventArgs e)
        {
            //if the stars hit the ground the restart at the beging of the form
            for (int i = 0; i < stars.Length / 2; i++)
            {
                stars[i].Top += starspeed;
                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -this.Height;
                }

            }
            //same thing but diffrent speed fo the other half of stars
            for (int i = stars.Length / 2; i < stars.Length; i++)
            {
                stars[i].Top += starspeed - 2;
                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -this.Height;
                }

            }
            label4.Text = "HP: " + Healthbar.ToString();
            label5.Text = "SCORE: " + score.ToString();
        }
        //make player move
        private void movetimer_Tick(object sender, EventArgs e)
        {
            
            if (moveLeft && player1.Left >= -10)
            {
                player1.Left -= playerspeed;
            }
            if (moveRight && player1.Right < this.Width)
            {
                player1.Left += playerspeed;
            }
            if (moveDown && player1.Bottom < this.Height - 40)
            {
                player1.Top += playerspeed;
            }
            if (moveUp && player1.Top > 0)
            {
                player1.Top -= playerspeed;
            }
            collisionOfShips_EnemiesBullets();
        }
        //check for keys pressed
        private void Form1_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (isPressed)
            {
                isPressed = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                moveDown = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                moveUp = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }
          
        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if(!pause)
            {
                if (e.KeyCode == Keys.Space && !isPressed)
                {
                    isPressed = true;

                    makeBullet();
                }
                if (e.KeyCode == Keys.Down)
                {
                    moveDown = true;
                }
                if (e.KeyCode == Keys.Up)
                {
                    moveUp = true;
                }
                if (e.KeyCode == Keys.Left)
                {
                    moveLeft = true;
                }
                if (e.KeyCode == Keys.Right)
                {
                    moveRight = true;
                }
              
            }
             if(e.KeyCode == Keys.P)
                {
                    if (!GameIsOver)
                    {
                        if (pause)
                        {
                            StartTimers();
                            label2.Visible = false;
                            gamemedia.controls.play();
                            pause = false;
                            starstimer1.Start();
                        }
                        else
                        {
                            label2.Visible = true;
                            gamemedia.controls.pause();
                            StopTimers();
                            pause = true;
                            starstimer1.Stop();
                        }
                    }
                } 
        }

        //creat stars
        private void starsBackground()
        {
            //creat stars in random locations
            starspeed = 5;
            stars = new PictureBox[30];
            rnd = new Random();
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new PictureBox();
                stars[i].BorderStyle = BorderStyle.None;
                stars[i].Location = new Point(rnd.Next(20, 500), rnd.Next(-10, 400));
                if (i % 2 == 1)
                {
                    stars[i].Size = new Size(2, 2);
                    stars[i].BackColor = Color.Wheat;
                }
                else
                {
                    stars[i].Size = new Size(3, 3);
                    stars[i].BackColor = Color.DarkGray;
                }
                this.Controls.Add(stars[i]);

            }

        }

        //creat a bullet
        private void makeBullet()
        {
            bullet = new PictureBox();
            bullet.Image = Image.FromFile(@"C:\Users\CompuMax\source\repos\SpaceWars\SpaceWars\bin\Debug\bullets.png");
            bullet.Tag = "bullet";
            bullet.Location = new Point(player1.Location.X + 15, player1.Location.Y - 10);
            bullet.Size = new Size(10, 10);
            bullet.SizeMode = PictureBoxSizeMode.Zoom;
            bullet.BorderStyle = BorderStyle.None;
            this.Controls.Add(bullet);
            shootmedia.controls.play();
        }
        //mainly sound tracks
        private void makeMedia()
        {
            gamemedia = new WindowsMediaPlayer();
            shootmedia = new WindowsMediaPlayer();
            explosion = new WindowsMediaPlayer();
            damage = new WindowsMediaPlayer();

            gamemedia.URL = @"C:\Users\CompuMax\source\repos\SPACE WARS\songs\GameSong.mp3";
            shootmedia.URL = @"C:\Users\CompuMax\source\repos\SPACE WARS\songs\shoot.mp3";
            explosion.URL = @"C:\Users\CompuMax\source\repos\SPACE WARS\songs\boom.mp3";
            damage.URL = @"C:\Users\CompuMax\Downloads\damage.mp3";


            gamemedia.settings.setMode("loop", true);
            gamemedia.settings.volume = 10;
            shootmedia.settings.volume = 5;
            explosion.settings.volume = 7;
            damage.settings.volume = 7;

            gamemedia.controls.play();

        }
        //creat enemies
        private void makeEnemies()
        {
            enemySpeed = 5;
            Image enemie1 = Image.FromFile(@"C:\Users\CompuMax\source\repos\SPACE WARS\asserts\E1.png");
            Image enemie2 = Image.FromFile(@"C:\Users\CompuMax\source\repos\SPACE WARS\asserts\E2.png");
            Image enemie3 = Image.FromFile(@"C:\Users\CompuMax\source\repos\SPACE WARS\asserts\E3.png");
            Image boss1 = Image.FromFile(@"C:\Users\CompuMax\source\repos\SPACE WARS\asserts\boss1.png");
            Image boss2 = Image.FromFile(@"C:\Users\CompuMax\source\repos\SPACE WARS\asserts\boss2.png");
            enemies = new PictureBox[12];
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new PictureBox();
                enemies[i].Size = new Size(40, 40);
                enemies[i].SizeMode = PictureBoxSizeMode.Zoom;
                enemies[i].BorderStyle = BorderStyle.None;
                enemies[i].Visible = false;
                this.Controls.Add(enemies[i]);
                enemies[i].Location = new Point((i + 1) * 38, -50);

            }
            enemies[1].Image = boss1;
            enemies[0].Image = enemie2;
            enemies[2].Image = enemie3;
            enemies[3].Image = enemie1;
            enemies[4].Image = enemie3;
            enemies[5].Image = boss2;
            enemies[6].Image = enemie3;
            enemies[7].Image = enemie1;
            enemies[8].Image = enemie3;
            enemies[9].Image = enemie1;
            enemies[10].Image = boss2;
            enemies[11].Image = enemie3;
            
        }
        //animated eneimes function
        private void moveEnemies(PictureBox[] arr, int speed)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i].Visible = true;
                arr[i].Top += speed;
                if (arr[i].Top >= this.Height)
                {
                    arr[i].Location = new Point((i + 1) * 50, -200);
                }
            }
        }

        private void collisonOfBullets()
        {
            foreach (Control j in this.Controls)
            {
                for (int i = 0; i < enemies.Length; i++)
                {
                    if ((j is PictureBox && j.Tag == "bullet") && (enemies[i].Bounds.IntersectsWith(j.Bounds)))
                    {
                        explosion.controls.play();
                        enemies[i].Location = new Point((i + 1) * 38, -100);
                        this.Controls.Remove(j);
                      
                       
                            score += 1;
                        



                    }

                }

            }

        }

        private void collisionOfShips_EnemiesBullets()
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].Bounds.IntersectsWith(player1.Bounds))
                {
                    enemies[i].Visible = false;
                    explosion.settings.volume = 40;
                     explosion.controls.play();
                    player1.Visible = false;
                    GameOver("GAME OVER");
                }
            }
            for (int i = 0; i <EnemiesBullets.Length; i++)
            {
                if(EnemiesBullets[i].Bounds.IntersectsWith(player1.Bounds))
                {
                    int x = rnd.Next(0, 11);
                    EnemiesBullets[i].Location = new Point(enemies[x].Location.X, enemies[x].Location.Y - 20);
                    damage.controls.play();
                    Healthbar -= 1;
                    if (Healthbar == 0)
                    {   
                       
                        explosion.settings.volume = 100;
                        explosion.controls.play();
                        player1.Visible = false;
                        GameOver("GAME OVER");

                    }

                }

            }

        }

        private void GameOver(string str)
        {
            GameIsOver = true;
            gamemedia.controls.stop();
            StopTimers();
            label1.Text = str;
            label1.Visible = true;
            replaybtn.Visible = true;
            exitbtn.Visible = true;
            
        }
        private void StopTimers()
        {
            movetimer.Stop();
            shoot_timer1.Stop();
            enemies_timer.Stop();

        }
        private void StartTimers()
        {
            enemies_timer.Start();
            shoot_timer1.Start();
            movetimer.Start();
           
        }
        private void MakeEnemiesBullets()
        {
            EnemiesBullets = new PictureBox[12];
            enemiesBulletSpeed = 3;
            for (int i = 0; i < EnemiesBullets.Length; i++)
            {
                EnemiesBullets[i] = new PictureBox();
                EnemiesBullets[i].Size = new Size(3, 12);
                EnemiesBullets[i].Visible = false; 
                EnemiesBullets[i].BackColor = Color.Yellow;
               
                int x = rnd.Next(0, 11);
                EnemiesBullets[i].Location = new Point(enemies[x].Location.X, enemies[x].Location.Y - 20);
                this.Controls.Add(EnemiesBullets[i]);

            }

        }
       
        
        






    }
}
