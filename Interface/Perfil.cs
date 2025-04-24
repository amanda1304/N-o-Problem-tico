﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login_Register.Model.Services;
using MySql.Data.MySqlClient;

namespace Login_Register
{
    public partial class Perfil : Form
    {
        public Perfil()
        {
            InitializeComponent();
           
        }
        int TogMove;
        int MValX;
        int MValY;
        private void Perfil_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = 1;
            MValX = e.X;
            MValY = e.Y;
        }

        private void Perfil_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = 0;
        }

        private void Perfil_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }

        private void btnSimbolos_Click(object sender, EventArgs e)
        {
            this.Hide();
            Jogos TelaJogos = new Jogos();
            TelaJogos.Show();
        }

        private void btnAmigos_Click(object sender, EventArgs e)
        {
            this.Hide();
            Amigos TelaAmigos = new Amigos();
            TelaAmigos.Show();
        }

        private void btnMatchMaking_Click(object sender, EventArgs e)
        {
            this.Hide();
            MatchMaking TelaMatch = new MatchMaking();
            TelaMatch.Show();
        }

        private void btnConfiguracoes_Click(object sender, EventArgs e)
        {
            this.Hide();
            Configurações Telaconfig = new Configurações();
            Telaconfig.Show();
        }

        private void btnMatchMakingLogo_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaInicial TelaInicial = new TelaInicial();
            TelaInicial.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            {
                DialogResult resultado = MessageBox.Show(
                    "Tem certeza que deseja sair?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    // Abre outro formulário
                    Login_Register loginregister = new Login_Register(); // substitua pelo seu form
                    loginregister.Show();

                    // Fecha o formulário atual
                    this.Close();
                }
            }
        }

        private void btnFecharTelaInicial_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                   "Tem certeza que deseja sair?",
                   "Confirmação",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question
               );

            if (resultado == DialogResult.Yes)
            {
                

                // Fecha o formulário atual
                this.Close();
            }
        }

        private void btnMinimizarTelaInicial_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Opacity += .2;
        }

        private void Perfil_Load(object sender, EventArgs e)
        {
            ConfiguracoesService configService = new ConfiguracoesService();
            pictureAvatar.Image = configService.CarregarAvatar(UserSession.userLogado.id);

            label2.Text = UserSession.userLogado.nome;
            timer2.Start();
            
        }
       
    }
}
