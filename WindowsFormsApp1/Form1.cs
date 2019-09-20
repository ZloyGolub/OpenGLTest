using SharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Start();
        }

        private void Start()
        {
            // Создаем экземпляр
            OpenGL gl = this.openGLControl1.OpenGL;
            float ballRadius = 0.6f;
            float ballX = 0.0f;
            float ballY = 0.0f;
            // Очистка экрана и буфера глубин
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
 
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            
            // Сбрасываем модельно-видовую матрицу
            gl.LoadIdentity();

            // Двигаем перо вглубь экрана
            gl.Translate(ballX, ballY, -3.0f);

            
            gl.Begin(OpenGL.GL_TRIANGLES);
            // Указываем цвет вершин
            
            gl.Color(0.0f, 0.0f, 1f);
            gl.Vertex(0.0f, 0.0f);
            int numSegments = 100;
            float angle, nextA;

            for (int i = 0; i <= numSegments; i++)
            { // Last vertex same as first vertex
                angle = i * 2.0f * (float)Math.PI / numSegments;  // 360 deg for all segments
                nextA = (i+1) * 2.0f * (float)Math.PI / numSegments;  // 360 deg for all segments
                gl.Vertex(Math.Cos(angle) * ballRadius, Math.Sin(angle) * (float)ballRadius);
                gl.Vertex(Math.Cos(nextA) * ballRadius, Math.Sin(nextA) * (float)ballRadius);
                gl.Vertex(0.0f, 0.0f);
            }
                            
            gl.End();//--------------------------------------------

            // Создаем экземпляр
            gl = this.openGLControl1.OpenGL;
            ballRadius = 0.4f;
            gl.MatrixMode(OpenGL.GL_MODELVIEW);

            // Сбрасываем модельно-видовую матрицу
            gl.LoadIdentity();

            // Двигаем перо вглубь экрана
            gl.Translate(ballX, ballY, -2.9f);


            gl.Begin(OpenGL.GL_TRIANGLES);
            // Указываем цвет вершин

            gl.Color(0.0f, 1f, 1f);
            gl.Vertex(0.0f, 0.0f);


            for (int i = 0; i <= numSegments; i++)
            { // Last vertex same as first vertex
                angle = i * 2.0f * (float)Math.PI / numSegments;  // 360 deg for all segments
                nextA = (i + 1) * 2.0f * (float)Math.PI / numSegments;  // 360 deg for all segments
                gl.Vertex(Math.Cos(angle) * ballRadius, Math.Sin(angle) * (float)ballRadius);
                gl.Vertex(Math.Cos(nextA) * ballRadius, Math.Sin(nextA) * (float)ballRadius);
                gl.Vertex(0.0f, 0.0f);
            }
                          
            gl.End();
            gl = this.openGLControl1.OpenGL;
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.LoadIdentity();
            gl.Translate(ballX, ballY, -2.8f);
            gl.Begin(OpenGL.GL_QUADS);

            gl.Color(1f, 1f, 1f);
            gl.Vertex(0.2f, 0.2f);
            gl.Vertex(0.2f, -0.2f);
            gl.Vertex(-0.2f, -0.2f);
            gl.Vertex(-0.2f, 0.2f);
            gl.End();
        }
        private void OpenGLControl1_Load(object sender, EventArgs e)
        {
            Start();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            Start();
        }
    }
}
