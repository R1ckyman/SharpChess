using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class Ajedrez : Form
    {
        char[,] tablero = new char[8, 8]
            { {'t','c','a','m','r','a','c','t'},
              {'p','p','p','p','p','p','p','p'},
              {' ',' ',' ',' ',' ',' ',' ',' '},
              {' ',' ',' ',' ',' ',' ',' ',' '},
              {' ',' ',' ',' ',' ',' ',' ',' '},
              {' ',' ',' ',' ',' ',' ',' ',' '},
              {'P','P','P','P','P','P','P','P'},
              {'T','C','A','M','R','A','C','T'},};

        bool jugador = true;
        bool dibujo = true;

        //Arrays para saber si es posible enrocar rey/torreI/torreD
        bool[] enroque_jugador1 = new bool[3] { true, true, true };
        bool[] enroque_jugador2 = new bool[3] { true, true, true };
        int[,] posiciones_jugador1 = new int[3, 2] { { 7, 4 }, { 7, 0 }, { 7, 7 } };
        int[,] posiciones_jugador2 = new int[3, 2] { { 0, 4 }, { 0, 0 }, { 0, 7 } };

        char Gficha;
        int Gfila;
        int Gcolumna;

        public Ajedrez()
        {
            InitializeComponent();
            mover.Enabled = false;
            dibujarTablero();

            this.FormClosing += Ajedrez_FormClosing;
        }
        //Al darle al 'X' de la ventana o alt + f4
        private void Ajedrez_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult eleccion = MessageBox.Show("¿Quiere cerrar la aplicación?", "Saliendo..", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (eleccion == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }
        //Al pulsar el botón de Menu
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu ventana = new App.Menu();
            ventana.Show();
        }

        //Al pulsar el botón de selecionar
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (TextX.Text.Length == 0 || TextY.Text.Length == 0)
            {
                MessageBox.Show("Íntroduce datos", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Char.IsDigit(TextX.Text[0]) || !System.Char.IsLetter(TextY.Text[0]))
            {
                MessageBox.Show("Íntroduce datos correctos", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int numero =  Int32.Parse(TextX.Text);
            char letra = TextY.Text[0];
            if (numero < 1 || numero > 8 || letra < 'A' || (letra > 'H' && letra < 'a') || letra >'h')
            {
                MessageBox.Show("Íntroduce datos correctos", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (jugador)
            {
                jugador1(numero, Char.ToUpper(letra));
            }
            else
            {
                jugador2(numero, Char.ToUpper(letra));
            }

        }

        //Al pulsar el botón de movimiento
        private void mover_Click(object sender, EventArgs e)
        {
            //Comprobación de coordenadas correctas
            if (TextX.Text.Length == 0 || TextY.Text.Length == 0)
            {
                MessageBox.Show("Íntroduce datos correctos", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Char.IsDigit(TextX.Text[0]) || !System.Char.IsLetter(TextY.Text[0]))
            {
                MessageBox.Show("Íntroduce datos correctos", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int numero = Int32.Parse(TextX.Text);
            char letra = TextY.Text[0];
            if (numero < 1 || numero > 8 || letra < 'A' || (letra > 'H' && letra < 'a') || letra > 'h')
            {
                MessageBox.Show("Íntroduce datos correctos", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int fila;
            int columna = (int)letra % 32 - 1;
            fila = arregloFila(numero);

            TextX.Text = "";
            TextY.Text = "";

            movimiento(fila, columna);
        }

        //Turno Jugador 1
        void jugador1(int numero, char letra)
        {
            char aux;
            int fila;
            int columna = (int)letra %32 -1;
            fila = arregloFila(numero);
            if (tablero[fila,columna] == 'p' || tablero[fila, columna] == 't' || tablero[fila, columna] == 'c' || tablero[fila, columna] == 'a' || tablero[fila, columna] == 'r' || tablero[fila, columna] == 'm' || tablero[fila, columna] == ' ')
            {
                MessageBox.Show("Selecciona una ficha correcta", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            aux = fichas(fila,columna);
            datosficha.Text = "Ficha: "+aux;
            switch (tablero[fila,columna])
            {
                case 'P':
                    Gficha = 'P';
                    Gfila = fila;
                    Gcolumna = columna;
                    peon(fila,columna);
                    break;
                case 'T':
                    Gficha = 'T';
                    Gfila = fila;
                    Gcolumna = columna;
                    torre(fila, columna);
                    break;
                case 'C':
                    Gficha = 'C';
                    Gfila = fila;
                    Gcolumna = columna;
                    caballo(fila, columna);
                    break;
                case 'A':
                    Gficha = 'A';
                    Gfila = fila;
                    Gcolumna = columna;
                    alfil(fila, columna);
                    break;
                case 'R':
                    Gficha = 'R';
                    Gfila = fila;
                    Gcolumna = columna;
                    rey(fila, columna);
                    break;
                case 'M':
                    Gficha = 'M';
                    Gfila = fila;
                    Gcolumna = columna;
                    reina(fila, columna);
                    break;
            }
        }

        //Turno Jugador 2
        void jugador2(int numero, char letra)
        {
            char aux;
            int fila;
            int columna = (int)letra % 32 - 1;
            fila = arregloFila(numero);
            if (tablero[fila, columna] == 'P' || tablero[fila, columna] == 'T' || tablero[fila, columna] == 'C' || tablero[fila, columna] == 'A' || tablero[fila, columna] == 'R' || tablero[fila, columna] == 'M' || tablero[fila, columna] == ' ')
            {
                MessageBox.Show("Selecciona una ficha correcta", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            aux = fichas(fila, columna);
            datosficha.Text = "Ficha: " + aux;
            switch (tablero[fila, columna])
            {
                case 'p':
                    Gficha = 'p';
                    Gfila = fila;
                    Gcolumna = columna;
                    peon(fila, columna);
                    break;
                case 't':
                    Gficha = 't';
                    Gfila = fila;
                    Gcolumna = columna;
                    torre(fila, columna);
                    break;
                case 'c':
                    Gficha = 'c';
                    Gfila = fila;
                    Gcolumna = columna;
                    caballo(fila, columna);
                    break;
                case 'a':
                    Gficha = 'a';
                    Gfila = fila;
                    Gcolumna = columna;
                    alfil(fila, columna);
                    break;
                case 'r':
                    Gficha = 'r';
                    Gfila = fila;
                    Gcolumna = columna;
                    rey(fila, columna);
                    break;
                case 'm':
                    Gficha = 'm';
                    Gfila = fila;
                    Gcolumna = columna;
                    reina(fila, columna);
                    break;
            }
        }

        //Si la ficha seleccionada es un peón se comprueban las acciones disponibles
        void peon(int fila,int columna)
        {
            String invalido1 = " PTCARM";
            String invalido2 = " ptcarm";
            int i;
            int contador1 = 0;
            int contador2 = 0;

            //Comprobación de posibles acciones con el peón del jugador 1
            if (jugador)
            {
                informacion.Text = "   ---Jugador 1---";
                if (tablero[fila-1, columna] == ' ')
                {
                    informacion.Text = informacion.Text + "\nMovimiento permitido, escriba las cordenadas donde quiera moverse.";
                    mover.Enabled = true;
                    btnSelect.Enabled = false;
                }
                for (i = 0; i < 7; i++)
                {
                    if (columna-1 > 0 && tablero[fila - 1, columna - 1] != invalido1[i])
                    {
                        contador1++;
                    }
                    if (columna+1 < 8 && tablero[fila - 1, columna + 1] != invalido1[i])
                    {
                        contador2++;
                    }
                }
                if (contador1 == 7 || contador2 == 7)
                {
                    informacion.Text = informacion.Text + "\nAtaque permitido, escriba las coordenadas donde desea atacar.";
                    mover.Enabled = true;
                    btnSelect.Enabled = false;
                }else
                {
                    informacion.Text = informacion.Text + "\nNinguna acción permitida con esta ficha.";
                }
                return;
            }
            //Comprobación de posibles acciones con el peón del jugador 2
            else
            {
                informacion.Text = "   ---Jugador 2---";
                if (tablero[fila + 1, columna] == ' ')
                {
                    informacion.Text = informacion.Text + "\nMovimiento permitido, escriba las cordenadas donde quiera moverse.";
                    mover.Enabled = true;
                }
                for (i = 0; i < 7; i++)
                {
                    if (columna - 1 > 0 && tablero[fila + 1, columna - 1] != invalido2[i])
                    {
                        contador1++;
                    }
                    if (columna + 1 < 8 && tablero[fila + 1, columna + 1] != invalido2[i])
                    {
                        contador2++;
                    }
                }
                if (contador1 == 7 || contador2 == 7)
                {
                    informacion.Text = informacion.Text + "\nAtaque permitido, escriba las coordenadas donde desea atacar.";
                    mover.Enabled = true;
                    btnSelect.Enabled = false;
                }
                else
                {
                    informacion.Text = informacion.Text + "\nNinguna acción permitida con esta ficha.";
                }
                return;
            }
        }

        //Si la ficha seleccionada es un caballo se comprueban las acciones disponibles
        void caballo(int fila, int columna)
        {
            String invalido1 = " PTCARM";
            String invalido2 = " ptcarm";
            int i;
            int contador = 0;

            //Comprobación de posibles acciones con el Caballo del jugador 1
            if (jugador)
            {
                informacion.Text = "   ---Jugador 1---";
                for (i = 0; i < 7; i++)
                {
                    //Comprobación de si hay un movimiento disponible sin salirse del array
                    if (((columna-1 > 0 && fila-2 > 0) && tablero[fila - 2, columna - 1] != invalido1[i]) || ((columna + 1 < 8 && fila - 2 > 0) && tablero[fila - 2, columna + 1] != invalido1[i]) || ((columna - 1 > 0 && fila + 2 < 8) && tablero[fila + 2, columna - 1] != invalido1[i]) || ((columna + 1 < 8 && fila + 2 < 8) && tablero[fila + 2, columna + 1] != invalido1[i]) || ((columna - 2 > 0 && fila - 1 > 0) && tablero[fila - 1, columna - 2] != invalido1[i]) || ((columna + 2 < 8 && fila - 1 > 0) && tablero[fila - 1, columna + 2] != invalido1[i]) || ((columna - 2 > 0 && fila + 1 < 8) && tablero[fila + 1, columna - 2] != invalido1[i]) || ((columna + 2 < 8 && fila + 1 < 8) && tablero[fila + 1, columna + 2] != invalido1[i]))
                    {
                        contador++;
                    }
                }
                if (contador == 7)
                {
                    informacion.Text = informacion.Text + "\nMovimiento permitido, escriba las coordenadas donde desea desplazarse/atacar.";
                    mover.Enabled = true;
                    btnSelect.Enabled = false;
                }else
                {
                    informacion.Text = informacion.Text + "\nNinguna acción permitida con esta ficha.";
                }
                return;
            }
            //Comprobación de posibles acciones con el Caballo del jugador 2
            else
            {
                informacion.Text = "   ---Jugador 2---";
                for (i = 0; i < 7; i++)
                {
                    //Comprobación de si hay un movimiento disponible sin salirse del array
                    if (((columna - 1 > 0 && fila - 2 > 0) && tablero[fila - 2, columna - 1] != invalido2[i]) || ((columna + 1 < 8 && fila - 2 > 0) && tablero[fila - 2, columna + 1] != invalido2[i]) || ((columna - 1 > 0 && fila + 2 < 8) && tablero[fila + 2, columna - 1] != invalido2[i]) || ((columna + 1 < 8 && fila + 2 < 8) && tablero[fila + 2, columna + 1] != invalido2[i]) || ((columna - 2 > 0 && fila - 1 > 0) && tablero[fila - 1, columna - 2] != invalido2[i]) || ((columna + 2 < 8 && fila - 1 > 0) && tablero[fila - 1, columna + 2] != invalido2[i]) || ((columna - 2 > 0 && fila + 1 < 8) && tablero[fila + 1, columna - 2] != invalido2[i]) || ((columna + 2 < 8 && fila + 1 < 8) && tablero[fila + 1, columna + 2] != invalido2[i]))
                    {
                        contador++;
                    }
                }
                if (contador == 7)
                {
                    informacion.Text = informacion.Text + "\nMovimiento permitido, escriba las coordenadas donde desea desplazarse/atacar.";
                    mover.Enabled = true;
                }
                if (mover.Enabled == false)
                {
                    informacion.Text = informacion.Text + "\nNinguna acción permitida con esta ficha.";
                }
                else
                {
                    btnSelect.Enabled = false;
                }
                return;
            }
        }

        //Si la ficha seleccionada es una torre se comprueban las acciones disponibles
        void torre(int fila, int columna)
        {
            String valido1 = " ptcarm"; 
            String valido2 = " PTCARM";
            int i;
            int contador;

            //Comprobación de posibles acciones con la torre del jugador 1
            if (jugador)
            {
                informacion.Text = "   ---Jugador 1---";

                contador = 0;
                for (i = 0; i < 7; i++)
                {
                    if ((fila-1>0 && tablero[fila - 1, columna] == valido1[i]) || (fila + 1 < 8 && tablero[fila + 1, columna] == valido1[i]) || (columna - 1 > 0 && tablero[fila, columna - 1] == valido1[i]) || (columna + 1 < 8 && tablero[fila, columna + 1] == valido1[i]))
                    {
                        contador++;
                    }
                }
                if (contador > 0)
                {
                    informacion.Text = informacion.Text + "\nMovimiento permitido, escriba las coordenadas donde desplazarse/atacar.";
                    mover.Enabled = true;
                    btnSelect.Enabled = false;
                }
                else
                {
                    informacion.Text = informacion.Text + "\nNinguna acción permitida con esta ficha.";
                }
                return;
            }
            //Comprobación de posibles acciones con la torre del jugador 2
            else
            {
                informacion.Text = "   ---Jugador 2---";
                contador = 0;
                for (i = 0; i < 7; i++)
                {
                    if ((fila - 1 > 0 && tablero[fila - 1, columna] == valido2[i]) || (fila + 1 < 8 && tablero[fila + 1, columna] == valido2[i]) || (columna - 1 > 0 && tablero[fila, columna - 1] == valido2[i]) || (columna + 1 < 8 && tablero[fila, columna + 1] == valido2[i]))
                    {
                        contador++;
                    }
                }
                if (contador > 0)
                {
                    informacion.Text = informacion.Text + "\nMovimiento permitido, escriba las coordenadas donde desplazarse/atacar.";
                    mover.Enabled = true;
                    btnSelect.Enabled = false;
                }
                else
                {
                    informacion.Text = informacion.Text + "\nNinguna acción permitida con esta ficha.";
                }
                return;
            }
        }

        //Si la ficha seleccionada es un alfil se comprueban las acciones disponibles
        void alfil(int fila, int columna)
        {
            String valido1 = " ptcarm";
            String valido2 = " PTCARM";
            int i;
            int contador;

            //Comprobación de posibles acciones con el alfi del jugador 1
            if (jugador)
            {
                informacion.Text = "   ---Jugador 1---";

                contador = 0;
                for (i = 0; i < 7; i++)
                {
                    if ((fila - 1 > 0 && columna - 1 > 0 && tablero[fila - 1, columna - 1] == valido1[i]) || (fila + 1 < 8 && columna - 1 > 0 && tablero[fila + 1, columna - 1] == valido1[i]) || (columna + 1 < 8 && fila + 1 < 8 && tablero[fila + 1, columna + 1] == valido1[i]) || (columna + 1 < 8 && fila - 1 > 0&& tablero[fila - 1, columna + 1] == valido1[i]))
                    {
                        contador++;
                    }
                }
                if (contador > 0)
                {
                    informacion.Text = informacion.Text + "\nMovimiento permitido, escriba las coordenadas donde desplazarse/atacar.";
                    mover.Enabled = true;
                    btnSelect.Enabled = false;
                }
                else
                {
                    informacion.Text = informacion.Text + "\nNinguna acción permitida con esta ficha.";
                }
                return;
            }
            //Comprobación de posibles acciones con el alfi del jugador 2
            else
            {
                informacion.Text = "   ---Jugador 2---";
                contador = 0;
                for (i = 0; i < 7; i++)
                {
                    if ((fila - 1 > 0 && tablero[fila - 1, columna] == valido2[i]) || (fila + 1 < 8 && tablero[fila + 1, columna] == valido2[i]) || (columna - 1 > 0 && tablero[fila, columna - 1] == valido2[i]) || (columna + 1 < 8 && tablero[fila, columna + 1] == valido2[i]))
                    {
                        contador++;
                    }
                }
                if (contador > 0)
                {
                    informacion.Text = informacion.Text + "\nMovimiento permitido, escriba las coordenadas donde desplazarse/atacar.";
                    mover.Enabled = true;
                    btnSelect.Enabled = false;
                }
                else
                {
                    informacion.Text = informacion.Text + "\nNinguna acción permitida con esta ficha.";
                }
                return;
            }
        }

        //Si la ficha seleccionada es una reina se comprueban las acciones disponibles
        void reina(int fila, int columna)
        {
            String valido1 = " ptcarm";
            String valido2 = " PTCARM";
            int i;
            int contador;

            //Comprobación de posibles acciones con la reina del jugador 1
            if (jugador)
            {
                informacion.Text = "   ---Jugador 1---";

                contador = 0;
                for (i = 0; i < 7; i++)
                {
                    if ((fila - 1 > 0 && tablero[fila - 1, columna] == valido1[i]) || (fila + 1 < 8 && tablero[fila + 1, columna] == valido1[i]) || (columna - 1 > 0 && tablero[fila, columna - 1] == valido1[i]) || (columna + 1 < 8 && tablero[fila, columna + 1] == valido1[i]))
                    {
                        contador++;
                    }
                }
                if (contador > 0)
                {
                    informacion.Text = informacion.Text + "\nMovimiento permitido, escriba las coordenadas donde desplazarse/atacar.";
                    mover.Enabled = true;
                    btnSelect.Enabled = false;
                    return;
                }
                contador = 0;
                for (i = 0; i < 7; i++)
                {
                    if ((fila - 1 > 0 && columna - 1 > 0 && tablero[fila - 1, columna - 1] == valido1[i]) || (fila + 1 < 8 && columna - 1 > 0 && tablero[fila + 1, columna - 1] == valido1[i]) || (columna + 1 < 8 && fila + 1 < 8 && tablero[fila + 1, columna + 1] == valido1[i]) || (columna + 1 < 8 && fila - 1 > 0 && tablero[fila - 1, columna + 1] == valido1[i]))
                    {
                        contador++;
                    }
                }
                if (contador > 0)
                {
                    informacion.Text = informacion.Text + "\nMovimiento permitido, escriba las coordenadas donde desplazarse/atacar.";
                    mover.Enabled = true;
                    btnSelect.Enabled = false;
                }
                else
                {
                    informacion.Text = informacion.Text + "\nNinguna acción permitida con esta ficha.";
                }
                return;
            }
            //Comprobación de posibles acciones con la reina del jugador 2
            else
            {
                informacion.Text = "   ---Jugador 2---";
                contador = 0;
                for (i = 0; i < 7; i++)
                {
                    if ((fila - 1 > 0 && tablero[fila - 1, columna] == valido2[i]) || (fila + 1 < 8 && tablero[fila + 1, columna] == valido2[i]) || (columna - 1 > 0 && tablero[fila, columna - 1] == valido2[i]) || (columna + 1 < 8 && tablero[fila, columna + 1] == valido2[i]))
                    {
                        contador++;
                    }
                }
                if (contador > 0)
                {
                    informacion.Text = informacion.Text + "\nMovimiento permitido, escriba las coordenadas donde desplazarse/atacar.";
                    mover.Enabled = true;
                    btnSelect.Enabled = false;
                    return;
                }
                contador = 0;
                for (i = 0; i < 7; i++)
                {
                    if ((fila - 1 > 0 && columna - 1 > 0 && tablero[fila - 1, columna - 1] == valido2[i]) || (fila + 1 < 8 && columna - 1 > 0 && tablero[fila + 1, columna - 1] == valido2[i]) || (columna + 1 < 8 && fila + 1 < 8 && tablero[fila + 1, columna + 1] == valido2[i]) || (columna + 1 < 8 && fila - 1 > 0 && tablero[fila - 1, columna + 1] == valido2[i]))
                    {
                        contador++;
                    }
                }
                if (contador > 0)
                {
                    informacion.Text = informacion.Text + "\nMovimiento permitido, escriba las coordenadas donde desplazarse/atacar.";
                    mover.Enabled = true;
                    btnSelect.Enabled = false;
                }
                else
                {
                    informacion.Text = informacion.Text + "\nNinguna acción permitida con esta ficha.";
                }
                return;
            }
        }

        //Si la ficha seleccionada es un rey se comprueban las acciones disponibles
        void rey(int fila, int columna)
        {
            String valido1 = " ptcarm";
            String valido2 = " PTCARM";
            int i;
            int contador;

            //Comprobación de posibles acciones con el rey del jugador 1
            if (jugador)
            {
                informacion.Text = "   ---Jugador 1---";

                contador = 0;
                for (i = 0; i < 7; i++)
                {
                    
                    if ((fila - 1 > 0 && tablero[fila - 1, columna] == valido1[i]) || (fila + 1 < 8 && tablero[fila + 1, columna] == valido1[i]) || (columna - 1 > 0 && tablero[fila, columna - 1] == valido1[i]) || (columna + 1 < 8 && tablero[fila, columna + 1] == valido1[i]) || (fila - 1 > 0 && columna - 1 > 0 && tablero[fila - 1, columna - 1] == valido1[i]) || (fila + 1 < 8 && columna - 1 > 0 && tablero[fila + 1, columna - 1] == valido1[i]) || (columna + 1 < 8 && fila + 1 < 8 && tablero[fila + 1, columna + 1] == valido1[i]) || (columna + 1 < 8 && fila - 1 > 0 && tablero[fila - 1, columna + 1] == valido1[i]))
                    {
                        contador++;
                    }
                }
                if (contador > 0)
                {
                    informacion.Text = informacion.Text + "\nMovimiento permitido, escriba las coordenadas donde desplazarse/atacar.";
                    mover.Enabled = true;
                    btnSelect.Enabled = false;
                    return;
                }else if(enroque_jugador1[0] && (tablero[Gfila,Gcolumna-1] == 'T' || tablero[Gfila, Gcolumna + 1] == 'T')){
                    informacion.Text = informacion.Text + "\nMovimiento permitido, escriba las coordenadas donde desplazarse/atacar.";
                    mover.Enabled = true;
                    btnSelect.Enabled = false;
                    return;
                }
                else
                {
                    informacion.Text = informacion.Text + "\nNinguna acción permitida con esta ficha.";
                }
                return;
            }
            //Comprobación de posibles acciones con el rey del jugador 2
            else
            {
                informacion.Text = "   ---Jugador 2---";
                contador = 0;
                for (i = 0; i < 7; i++)
                {
                    if ((fila - 1 > 0 && tablero[fila - 1, columna] == valido2[i]) || (fila + 1 < 8 && tablero[fila + 1, columna] == valido2[i]) || (columna - 1 > 0 && tablero[fila, columna - 1] == valido2[i]) || (columna + 1 < 8 && tablero[fila, columna + 1] == valido2[i]) || (fila - 1 > 0 && columna - 1 > 0 && tablero[fila - 1, columna - 1] == valido2[i]) || (fila + 1 < 8 && columna - 1 > 0 && tablero[fila + 1, columna - 1] == valido2[i]) || (columna + 1 < 8 && fila + 1 < 8 && tablero[fila + 1, columna + 1] == valido2[i]) || (columna + 1 < 8 && fila - 1 > 0 && tablero[fila - 1, columna + 1] == valido2[i]))
                    {
                        contador++;
                    }
                }
                if (contador > 0)
                {
                    informacion.Text = informacion.Text + "\nMovimiento permitido, escriba las coordenadas donde desplazarse/atacar.";
                    mover.Enabled = true;
                    btnSelect.Enabled = false;
                }
                else if (enroque_jugador2[0] && (tablero[Gfila, Gcolumna - 1] == 't' || tablero[Gfila, Gcolumna + 1] == 't'))
                {
                    informacion.Text = informacion.Text + "\nMovimiento permitido, escriba las coordenadas donde desplazarse/atacar.";
                    mover.Enabled = true;
                    btnSelect.Enabled = false;
                    return;
                }
                else
                {
                    informacion.Text = informacion.Text + "\nNinguna acción permitida con esta ficha.";
                }
                return;
            }
        }

        //Todas las reglas de movimiento y ataque al pulsar el botón de movimiento
        void movimiento(int fila, int columna)
        {
            int i,y, invalido;
            switch (Gficha)
            {
                //Peón Jugador 1
                case 'P':
                    //Si es un movimiento normal
                     if (columna == Gcolumna)
                    {
                        if (Gfila == fila+1 && tablero[fila, columna] == ' ')
                        {
                            tablero[Gfila, Gcolumna] = ' ';
                            tablero[fila, columna] = 'P';
                            cambioJugador();
                            return;
                        }
                        else if (Gfila == fila+2 && tablero[fila, columna] == ' ' && tablero[fila+1, columna] == ' ')
                        {
                            tablero[Gfila, Gcolumna] = ' ';
                            tablero[fila, columna] = 'P';
                            cambioJugador();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Íntroduce un movimiento válido");
                            return;
                        }
                    }
                     //Si es un movimiento de ataque
                    else
                    {
                        if (fila != Gfila - 1)
                        {
                            MessageBox.Show("Íntroduce unas coordenadas válidas");
                            return;
                        }
                    }
                     if (tablero[fila, columna] == 'p' || tablero[fila, columna] == 't' || tablero[fila, columna] == 'c' || tablero[fila, columna] == 'a' || tablero[fila, columna] == 'm')
                    {
                        tablero[Gfila, Gcolumna] = ' ';
                        tablero[fila, columna] = 'P';
                        cambioJugador();
                        return;
                       }
                     else
                       {
                          MessageBox.Show("Íntroduce unas coordenadas válidas");
                          return;
                       }
                //Peón Jugador 2
                case 'p':
                    //Si es un movimiento normal
                    if (columna == Gcolumna)
                    {
                        MessageBox.Show("Tablero: " + tablero[fila, columna]);
                        if (Gfila == fila - 1 && tablero[fila, columna] == ' ')
                        {
                            tablero[Gfila, Gcolumna] = ' ';
                            tablero[fila, columna] = 'p';
                            cambioJugador();
                            return;
                        }
                        else if (Gfila == fila - 2 && tablero[fila, columna] == ' ' && tablero[fila-1, columna] == ' ')
                        {
                            tablero[Gfila, Gcolumna] = ' ';
                            tablero[fila, columna] = 'p';
                            cambioJugador();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Íntroduce un movimiento válido");
                            return;
                        }
                    }
                    //Si es un movimiento de ataque
                    if (fila != Gfila + 1)
                    {
                        MessageBox.Show("Íntroduce unas coordenadas válidas");
                        return;
                    }
                    if (tablero[fila, columna] == 'P' || tablero[fila, columna] == 'T' || tablero[fila, columna] == 'C' || tablero[fila, columna] == 'A' || tablero[fila, columna] == 'M')
                    {
                        tablero[Gfila, Gcolumna] = ' ';
                        tablero[fila, columna] = 'p';
                        cambioJugador();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Íntroduce unas coordenadas válidas");
                        return;
                    }
                case 'C':
                    //Se comprueba que las coordenadas coinciden con el movimiento del caballo
                    if ((fila != Gfila - 1 || columna != Gcolumna+2) && (fila != Gfila - 1 || columna != Gcolumna - 2) && (fila != Gfila + 1 || columna != Gcolumna + 2) && (fila != Gfila + 1 || columna != Gcolumna - 2) && (fila != Gfila - 2 || columna != Gcolumna + 1) && (fila != Gfila - 2 || columna != Gcolumna - 1) && (fila != Gfila + 2 || columna != Gcolumna + 1) && (fila != Gfila + 2 || columna != Gcolumna - 1))
                    {
                        MessageBox.Show("Íntroduce unas coordenadas válidas");
                        return;
                    }
                    if (tablero[fila, columna] == ' ' || tablero[fila, columna] == 'p' || tablero[fila, columna] == 't' || tablero[fila, columna] == 'c' || tablero[fila, columna] == 'a' || tablero[fila, columna] == 'm')
                    {
                        tablero[Gfila, Gcolumna] = ' ';
                        tablero[fila, columna] = 'C';
                        cambioJugador();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Íntroduce unas coordenadas válidas");
                        return;
                    }
                case 'c':
                    //Se comprueba que las coordenadas coinciden con el movimiento del caballo
                    if ((fila != Gfila - 1 || columna != Gcolumna + 2) && (fila != Gfila - 1 || columna != Gcolumna - 2) && (fila != Gfila + 1 || columna != Gcolumna + 2) && (fila != Gfila + 1 || columna != Gcolumna - 2) && (fila != Gfila - 2 || columna != Gcolumna + 1) && (fila != Gfila - 2 || columna != Gcolumna - 1) && (fila != Gfila + 2 || columna != Gcolumna + 1) && (fila != Gfila + 2 || columna != Gcolumna - 1))
                    {
                        MessageBox.Show("Íntroduce unas coordenadas válidas");
                        return;
                    }
                    if (tablero[fila, columna] == ' ' || tablero[fila, columna] == 'P' || tablero[fila, columna] == 'T' || tablero[fila, columna] == 'C' || tablero[fila, columna] == 'A' || tablero[fila, columna] == 'M')
                    {
                        tablero[Gfila, Gcolumna] = ' ';
                        tablero[fila, columna] = 'c';
                        cambioJugador();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Íntroduce unas coordenadas válidas");
                        return;
                    }
                case 'T':
                    //Si el destino de la torre es una ficha inválida
                    if (tablero[fila, columna] != ' ' && tablero[fila, columna] != 'p' && tablero[fila, columna] != 't' && tablero[fila, columna] != 'c' && tablero[fila, columna] != 'a' && tablero[fila, columna] != 'r' && tablero[fila, columna] != 'm')
                    {
                        MessageBox.Show("Íntroduce unas coordenadas válidas", "Coordenadas inválidas",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        return;
                    }
                    invalido = 0;
                    //Se comprueba si la torre se mueve en horizontal o en vertical
                    if (fila == Gfila && columna != Gcolumna)
                    {
                        //Si se mueve hacia la derecha
                        if (columna > Gcolumna)
                        {
                                for (i = Gcolumna + 1; i < 7; i++)
                                {
                                    if (columna == i)
                                    {
                                        break;
                                    }
                                    if (tablero[fila, i] != ' ')
                                    {
                                        invalido = 1;
                                        break;
                                    }
                                }
                        }
                        //Si se mueve hacia la izquierda
                        else
                        {
                                for (i = Gcolumna - 1; i > 0; i--)
                                {
                                    if (columna == i)
                                    {
                                        break;
                                    }
                                    if (tablero[fila, i] != ' ')
                                    {
                                        invalido = 1;
                                        break;
                                    }
                                }
                        }
                    } else if (fila != Gfila && columna == Gcolumna)
                    {
                        //Si se mueve hacia arriba
                        if (Gfila > fila)
                        {
                                for (i = Gfila - 1; i < 7; i--)
                                {
                                    if (fila == i)
                                    {
                                        break;
                                    }
                                    if (tablero[i, columna] != ' ')
                                    {
                                        invalido = 1;
                                        break;
                                    }
                                }
                        }
                        //Si se mueve hacia abajo
                        else
                        {
                                for (i = Gfila + 1; i > 0; i++)
                                {
                                    if (fila == i)
                                    {
                                        break;
                                    }
                                    if (tablero[i, columna] != ' ')
                                    {
                                        invalido = 1;
                                        break;
                                    }
                                }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Introduce coordenadas correctas");
                        return;
                    }
                    if (invalido == 0)
                    {
                        tablero[Gfila, Gcolumna] = ' ';
                        tablero[fila, columna] = 'T';
                        cambioJugador();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Movimiento incorrecto");
                        return;
                    }
                case 't':
                    //Si el destino de la torre es una ficha inválida
                    if (tablero[fila, columna] != ' ' && tablero[fila, columna] != 'P' && tablero[fila, columna] != 'T' && tablero[fila, columna] != 'C' && tablero[fila, columna] != 'A' && tablero[fila, columna] != 'R' && tablero[fila, columna] != 'M')
                    {
                        MessageBox.Show("Íntroduce unas coordenadas válidas");
                        return;
                    }
                    invalido = 0;
                    //Se comprueba si la torre se mueve en horizontal o en vertical
                    if (fila == Gfila && columna != Gcolumna)
                    {
                        //Si se mueve hacia la derecha
                        if (columna > Gcolumna)
                        {
                            for (i = Gcolumna + 1; i < 7; i++)
                            {
                                if (columna == i)
                                {
                                    break;
                                }
                                if (tablero[fila, i] != ' ')
                                {
                                    invalido = 1;
                                    break;
                                }
                            }
                        }
                        //Si se mueve hacia la izquierda
                        else
                        {
                            for (i = Gcolumna - 1; i > 0; i--)
                            {
                                if (columna == i)
                                {
                                    break;
                                }
                                if (tablero[fila, i] != ' ')
                                {
                                    invalido = 1;
                                    break;
                                }
                            }
                        }
                    }
                    else if (fila != Gfila && columna == Gcolumna)
                    {
                        //Si se mueve hacia arriba
                        if (Gfila > fila)
                        {
                            for (i = Gfila - 1; i < 7; i--)
                            {
                                if (fila == i)
                                {
                                    break;
                                }
                                if (tablero[i, columna] != ' ')
                                {
                                    invalido = 1;
                                    break;
                                }
                            }
                        }
                        //Si se mueve hacia abajo
                        else
                        {
                            for (i = Gfila + 1; i > 0; i++)
                            {
                                if (fila == i)
                                {
                                    break;
                                }
                                if (tablero[i, columna] != ' ')
                                {
                                    invalido = 1;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Introduce coordenadas correctas");
                        return;
                    }
                    if (invalido == 0)
                    {
                        tablero[Gfila, Gcolumna] = ' ';
                        tablero[fila, columna] = 't';
                        cambioJugador();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Movimiento incorrecto");
                        return;
                    }
                case 'A':
                    //Si el destino del alfil es una ficha inválida
                    if (tablero[fila, columna] != ' ' && tablero[fila, columna] != 'p' && tablero[fila, columna] != 't' && tablero[fila, columna] != 'c' && tablero[fila, columna] != 'a' && tablero[fila, columna] != 'r' && tablero[fila, columna] != 'm')
                    {
                        MessageBox.Show("Íntroduce unas coordenadas válidas", "Coordenadas inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // Si se mueve solo en el eje Y o en el eje X
                    if (columna == Gcolumna || Gfila == fila)
                    {
                        MessageBox.Show("Íntroduce unas coordenadas válidas", "Coordenadas inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    invalido = 0;
                    //Se comprueba si el alfil se mueve hacia arriba
                    if (Gfila > fila && columna != Gcolumna)
                    {
                        //Si se mueve hacia ArribaDerecha
                        if (columna > Gcolumna)
                        {
                            //Este bucle es para condiciones por las que no se puede mover
                            i = Gfila - 1;
                            for (y = Gcolumna + 1; y < 7; y++)
                            {
                                if (fila == i && columna == y)
                                {
                                    break;
                                }
                                else if ((fila == i && columna != y) || (fila != i && columna == y))
                                {
                                    invalido = 1;
                                    break;
                                }
                                if (tablero[i, y] != ' ')
                                {
                                    invalido = 1;
                                }
                                //Igual es para que no se salga del rango
                                if (i == 0)
                                {
                                    i = Gfila - 1;
                                }
                                else
                                {
                                    i--;
                                }
                            }
                        }
                        //Si se mueve hacia ArribaIzquierda
                        else
                        {
                            //Este bucle es para condiciones por las que no se puede mover
                            i = Gfila - 1;
                            for (y = Gcolumna - 1; y >= 0; y--)
                            {
                                if (fila == i && columna == y)
                                {
                                    break;
                                }
                                else if ((fila == i && columna != y) || (fila != i && columna == y))
                                {
                                    invalido = 1;
                                    break;
                                }
                                if (tablero[i, y] != ' ')
                                {
                                    invalido = 1;
                                }
                                //Igual es para que no se salga del rango
                                if (i == 0)
                                {
                                    i = Gfila - 1;
                                }
                                else
                                {
                                    i--;
                                }
                            }
                        }
                    }
                    //Si se mueve hacia abajo
                    else if (Gfila < fila && columna != Gcolumna)
                    {
                        //Si se mueve hacia AbajoDerecha
                        if (columna > Gcolumna)
                        {
                            i = Gfila + 1;
                            for (y = Gcolumna + 1; y < 7; y++)
                            {
                                if (fila == i && columna == y)
                                {
                                    break;
                                }
                                else if ((fila == i && columna != y) || (fila != i && columna == y))
                                {
                                    invalido = 1;
                                    break;
                                }
                                if (tablero[i, y] != ' ')
                                {
                                    invalido = 1;
                                }
                                //Igual es para que no se salga del rango
                                if (i == 7)
                                {
                                    i = Gfila + 1;
                                }
                                else
                                {
                                    i++;
                                }
                            }
                        }
                        //Si se mueve hacia AbajoIzquierda
                        else
                        {
                            //Este bucle es para condiciones por las que no se puede mover
                            i = Gfila + 1;
                            for (y = Gcolumna - 1; y >= 0; y--)
                            {
                                if (fila == i && columna == y)
                                {
                                    break;
                                }
                                else if ((fila == i && columna != y) || (fila != i && columna == y))
                                {
                                    invalido = 1;
                                    break;
                                }
                                if (tablero[i, y] != ' ')
                                {
                                    invalido = 1;
                                }
                                //Igual es para que no se salga del rango
                                if (i == 7)
                                {
                                    i = Gfila + 1;
                                }
                                else
                                {
                                    i++;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Introduce coordenadas correctas", "Datos incorrectos");
                        return;
                    }
                    if (invalido == 0)
                    {
                        tablero[Gfila, Gcolumna] = ' ';
                        tablero[fila, columna] = 'A';
                        cambioJugador();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Movimiento incorrecto", "Datos incorrectos");
                        return;
                    }
                case 'a':
                    //Si el destino del alfil es una ficha inválida
                    if (tablero[fila, columna] != ' ' && tablero[fila, columna] != 'P' && tablero[fila, columna] != 'T' && tablero[fila, columna] != 'C' && tablero[fila, columna] != 'A' && tablero[fila, columna] != 'R' && tablero[fila, columna] != 'M')
                    {
                        MessageBox.Show("Íntroduce unas coordenadas válidas", "Coordenadas inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // Si se mueve solo en el eje Y o en el eje X
                    if (columna == Gcolumna || Gfila == fila)
                    {
                        MessageBox.Show("Íntroduce unas coordenadas válidas", "Coordenadas inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    invalido = 0;
                    //Se comprueba si el alfil se mueve hacia arriba
                    if (Gfila > fila && columna != Gcolumna)
                    {
                        //Si se mueve hacia ArribaDerecha
                        if (columna > Gcolumna)
                        {
                            //Este bucle es para condiciones por las que no se puede mover
                            i = Gfila - 1;
                            for (y = Gcolumna + 1; y < 7; y++)
                            {
                                if (fila == i && columna == y)
                                {
                                    break;
                                }
                                else if ((fila == i && columna != y) || (fila != i && columna == y))
                                {
                                    invalido = 1;
                                    break;
                                }
                                if (tablero[i, y] != ' ')
                                {
                                    invalido = 1;
                                }
                                //Igual es para que no se salga del rango
                                if (i == 0)
                                {
                                    i = Gfila - 1;
                                }
                                else
                                {
                                    i--;
                                }
                            }
                        }
                        //Si se mueve hacia ArribaIzquierda
                        else
                        {
                            //Este bucle es para condiciones por las que no se puede mover
                            i = Gfila - 1;
                            for (y = Gcolumna - 1; y >= 0; y--)
                            {
                                if (fila == i && columna == y)
                                {
                                    break;
                                }
                                else if ((fila == i && columna != y) || (fila != i && columna == y))
                                {
                                    invalido = 1;
                                    break;
                                }
                                if (tablero[i, y] != ' ')
                                {
                                    invalido = 1;
                                }
                                //Igual es para que no se salga del rango
                                if (i == 0)
                                {
                                    i = Gfila - 1;
                                }
                                else
                                {
                                    i--;
                                }
                            }
                        }
                    }
                    //Si se mueve hacia abajo
                    else if (Gfila < fila && columna != Gcolumna)
                    {
                        //Si se mueve hacia AbajoDerecha
                        if (columna > Gcolumna)
                        {
                            i = Gfila + 1;
                            for (y = Gcolumna + 1; y < 7; y++)
                            {
                                if (fila == i && columna == y)
                                {
                                    break;
                                }
                                else if ((fila == i && columna != y) || (fila != i && columna == y))
                                {
                                    invalido = 1;
                                    break;
                                }
                                if (tablero[i, y] != ' ')
                                {
                                    invalido = 1;
                                }
                                //Igual es para que no se salga del rango
                                if (i == 7)
                                {
                                    i = Gfila + 1;
                                }
                                else
                                {
                                    i++;
                                }
                            }
                        }
                        //Si se mueve hacia AbajoIzquierda
                        else
                        {
                            //Este bucle es para condiciones por las que no se puede mover
                            i = Gfila + 1;
                            for (y = Gcolumna - 1; y >= 0; y--)
                            {
                                if (fila == i && columna == y)
                                {
                                    break;
                                }
                                else if ((fila == i && columna != y) || (fila != i && columna == y))
                                {
                                    invalido = 1;
                                    break;
                                }
                                if (tablero[i, y] != ' ')
                                {
                                    invalido = 1;
                                }
                                //Igual es para que no se salga del rango
                                if (i == 7)
                                {
                                    i = Gfila + 1;
                                }
                                else
                                {
                                    i++;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Introduce coordenadas correctas", "Datos incorrectos");
                        return;
                    }
                    if (invalido == 0)
                    {
                        tablero[Gfila, Gcolumna] = ' ';
                        tablero[fila, columna] = 'a';
                        cambioJugador();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Movimiento incorrecto", "Datos incorrectos");
                        return;
                    }
                case 'M':
                    //Si el destino de la reina es una ficha inválida
                    if (tablero[fila, columna] != ' ' && tablero[fila, columna] != 'p' && tablero[fila, columna] != 't' && tablero[fila, columna] != 'c' && tablero[fila, columna] != 'a' && tablero[fila, columna] != 'r' && tablero[fila, columna] != 'm')
                    {
                        MessageBox.Show("Íntroduce unas coordenadas válidas", "Coordenadas inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // Si se mueve solo en el eje Y o en el eje X
                    if (columna == Gcolumna || Gfila == fila)
                    {
                        invalido = 0;
                        //Se comprueba si la torre se mueve en horizontal o en vertical
                        if (fila == Gfila && columna != Gcolumna)
                        {
                            //Si se mueve hacia la derecha
                            if (columna > Gcolumna)
                            {
                                for (i = Gcolumna + 1; i < 7; i++)
                                {
                                    if (columna == i)
                                    {
                                        break;
                                    }
                                    if (tablero[fila, i] != ' ')
                                    {
                                        invalido = 1;
                                        break;
                                    }
                                }
                            }
                            //Si se mueve hacia la izquierda
                            else
                            {
                                for (i = Gcolumna - 1; i > 0; i--)
                                {
                                    if (columna == i)
                                    {
                                        break;
                                    }
                                    if (tablero[fila, i] != ' ')
                                    {
                                        invalido = 1;
                                        break;
                                    }
                                }
                            }
                        }
                        else if (fila != Gfila && columna == Gcolumna)
                        {
                            //Si se mueve hacia arriba
                            if (Gfila > fila)
                            {
                                for (i = Gfila - 1; i < 7; i--)
                                {
                                    if (fila == i)
                                    {
                                        break;
                                    }
                                    if (tablero[i, columna] != ' ')
                                    {
                                        invalido = 1;
                                        break;
                                    }
                                }
                            }
                            //Si se mueve hacia abajo
                            else
                            {
                                for (i = Gfila + 1; i > 0; i++)
                                {
                                    if (fila == i)
                                    {
                                        break;
                                    }
                                    if (tablero[i, columna] != ' ')
                                    {
                                        invalido = 1;
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Introduce coordenadas correctas");
                            return;
                        }
                        if (invalido == 0)
                        {
                            tablero[Gfila, Gcolumna] = ' ';
                            tablero[fila, columna] = 'M';
                            cambioJugador();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Movimiento incorrecto");
                            return;
                        }
                    }
                    invalido = 0;
                    //Se comprueba si el alfil se mueve hacia arriba
                    if (Gfila > fila && columna != Gcolumna)
                    {
                        //Si se mueve hacia ArribaDerecha
                        if (columna > Gcolumna)
                        {
                            //Este bucle es para condiciones por las que no se puede mover
                            i = Gfila - 1;
                            for (y = Gcolumna + 1; y < 7; y++)
                            {
                                if (fila == i && columna == y)
                                {
                                    break;
                                }
                                else if ((fila == i && columna != y) || (fila != i && columna == y))
                                {
                                    invalido = 1;
                                    break;
                                }
                                if (tablero[i, y] != ' ')
                                {
                                    invalido = 1;
                                }
                                //Igual es para que no se salga del rango
                                if (i == 0)
                                {
                                    i = Gfila - 1;
                                }
                                else
                                {
                                    i--;
                                }
                            }
                        }
                        //Si se mueve hacia ArribaIzquierda
                        else
                        {
                            //Este bucle es para condiciones por las que no se puede mover
                            i = Gfila - 1;
                            for (y = Gcolumna - 1; y >= 0; y--)
                            {
                                if (fila == i && columna == y)
                                {
                                    break;
                                }
                                else if ((fila == i && columna != y) || (fila != i && columna == y))
                                {
                                    invalido = 1;
                                    break;
                                }
                                if (tablero[i, y] != ' ')
                                {
                                    invalido = 1;
                                }
                                //Igual es para que no se salga del rango
                                if (i == 0)
                                {
                                    i = Gfila - 1;
                                }
                                else
                                {
                                    i--;
                                }
                            }
                        }
                    }
                    //Si se mueve hacia abajo
                    else if (Gfila < fila && columna != Gcolumna)
                    {
                        //Si se mueve hacia AbajoDerecha
                        if (columna > Gcolumna)
                        {
                            i = Gfila + 1;
                            for (y = Gcolumna + 1; y < 7; y++)
                            {
                                if (fila == i && columna == y)
                                {
                                    break;
                                }
                                else if ((fila == i && columna != y) || (fila != i && columna == y))
                                {
                                    invalido = 1;
                                    break;
                                }
                                if (tablero[i, y] != ' ')
                                {
                                    invalido = 1;
                                }
                                //Igual es para que no se salga del rango
                                if (i == 7)
                                {
                                    i = Gfila + 1;
                                }
                                else
                                {
                                    i++;
                                }
                            }
                        }
                        //Si se mueve hacia AbajoIzquierda
                        else
                        {
                            //Este bucle es para condiciones por las que no se puede mover
                            i = Gfila + 1;
                            for (y = Gcolumna - 1; y >= 0; y--)
                            {
                                if (fila == i && columna == y)
                                {
                                    break;
                                }
                                else if ((fila == i && columna != y) || (fila != i && columna == y))
                                {
                                    invalido = 1;
                                    break;
                                }
                                if (tablero[i, y] != ' ')
                                {
                                    invalido = 1;
                                }
                                //Igual es para que no se salga del rango
                                if (i == 7)
                                {
                                    i = Gfila + 1;
                                }
                                else
                                {
                                    i++;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Introduce coordenadas correctas", "Datos incorrectos");
                        return;
                    }
                    if (invalido == 0)
                    {
                        tablero[Gfila, Gcolumna] = ' ';
                        tablero[fila, columna] = 'M';
                        cambioJugador();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Movimiento incorrecto", "Datos incorrectos");
                        return;
                    }
                case 'm':
                    //Si el destino del alfil es una ficha inválida
                    if (tablero[fila, columna] != ' ' && tablero[fila, columna] != 'P' && tablero[fila, columna] != 'T' && tablero[fila, columna] != 'C' && tablero[fila, columna] != 'A' && tablero[fila, columna] != 'R' && tablero[fila, columna] != 'M')
                    {
                        MessageBox.Show("Íntroduce unas coordenadas válidas", "Coordenadas inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // Si se mueve solo en el eje Y o en el eje X
                    if (columna == Gcolumna || Gfila == fila)
                    {
                        invalido = 0;
                        //Se comprueba si la torre se mueve en horizontal o en vertical
                        if (fila == Gfila && columna != Gcolumna)
                        {
                            //Si se mueve hacia la derecha
                            if (columna > Gcolumna)
                            {
                                for (i = Gcolumna + 1; i < 7; i++)
                                {
                                    if (columna == i)
                                    {
                                        break;
                                    }
                                    if (tablero[fila, i] != ' ')
                                    {
                                        invalido = 1;
                                        break;
                                    }
                                }
                            }
                            //Si se mueve hacia la izquierda
                            else
                            {
                                for (i = Gcolumna - 1; i > 0; i--)
                                {
                                    if (columna == i)
                                    {
                                        break;
                                    }
                                    if (tablero[fila, i] != ' ')
                                    {
                                        invalido = 1;
                                        break;
                                    }
                                }
                            }
                        }
                        else if (fila != Gfila && columna == Gcolumna)
                        {
                            //Si se mueve hacia arriba
                            if (Gfila > fila)
                            {
                                for (i = Gfila - 1; i < 7; i--)
                                {
                                    if (fila == i)
                                    {
                                        break;
                                    }
                                    if (tablero[i, columna] != ' ')
                                    {
                                        invalido = 1;
                                        break;
                                    }
                                }
                            }
                            //Si se mueve hacia abajo
                            else
                            {
                                for (i = Gfila + 1; i > 0; i++)
                                {
                                    if (fila == i)
                                    {
                                        break;
                                    }
                                    if (tablero[i, columna] != ' ')
                                    {
                                        invalido = 1;
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Introduce coordenadas correctas");
                            return;
                        }
                        if (invalido == 0)
                        {
                            tablero[Gfila, Gcolumna] = ' ';
                            tablero[fila, columna] = 'm';
                            cambioJugador();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Movimiento incorrecto");
                            return;
                        }
                    }
                    invalido = 0;
                    //Se comprueba si el alfil se mueve hacia arriba
                    if (Gfila > fila && columna != Gcolumna)
                    {
                        //Si se mueve hacia ArribaDerecha
                        if (columna > Gcolumna)
                        {
                            //Este bucle es para condiciones por las que no se puede mover
                            i = Gfila - 1;
                            for (y = Gcolumna + 1; y < 7; y++)
                            {
                                if (fila == i && columna == y)
                                {
                                    break;
                                }
                                else if ((fila == i && columna != y) || (fila != i && columna == y))
                                {
                                    invalido = 1;
                                    break;
                                }
                                if (tablero[i, y] != ' ')
                                {
                                    invalido = 1;
                                }
                                //Igual es para que no se salga del rango
                                if (i == 0)
                                {
                                    i = Gfila - 1;
                                }
                                else
                                {
                                    i--;
                                }
                            }
                        }
                        //Si se mueve hacia ArribaIzquierda
                        else
                        {
                            //Este bucle es para condiciones por las que no se puede mover
                            i = Gfila - 1;
                            for (y = Gcolumna - 1; y >= 0; y--)
                            {
                                if (fila == i && columna == y)
                                {
                                    break;
                                }
                                else if ((fila == i && columna != y) || (fila != i && columna == y))
                                {
                                    invalido = 1;
                                    break;
                                }
                                if (tablero[i, y] != ' ')
                                {
                                    invalido = 1;
                                }
                                //Igual es para que no se salga del rango
                                if (i == 0)
                                {
                                    i = Gfila - 1;
                                }
                                else
                                {
                                    i--;
                                }
                            }
                        }
                    }
                    //Si se mueve hacia abajo
                    else if (Gfila < fila && columna != Gcolumna)
                    {
                        //Si se mueve hacia AbajoDerecha
                        if (columna > Gcolumna)
                        {
                            i = Gfila + 1;
                            for (y = Gcolumna + 1; y < 7; y++)
                            {
                                if (fila == i && columna == y)
                                {
                                    break;
                                }
                                else if ((fila == i && columna != y) || (fila != i && columna == y))
                                {
                                    invalido = 1;
                                    break;
                                }
                                if (tablero[i, y] != ' ')
                                {
                                    invalido = 1;
                                }
                                //Igual es para que no se salga del rango
                                if (i == 7)
                                {
                                    i = Gfila + 1;
                                }
                                else
                                {
                                    i++;
                                }
                            }
                        }
                        //Si se mueve hacia AbajoIzquierda
                        else
                        {
                            //Este bucle es para condiciones por las que no se puede mover
                            i = Gfila + 1;
                            for (y = Gcolumna - 1; y >= 0; y--)
                            {
                                if (fila == i && columna == y)
                                {
                                    break;
                                }
                                else if ((fila == i && columna != y) || (fila != i && columna == y))
                                {
                                    invalido = 1;
                                    break;
                                }
                                if (tablero[i, y] != ' ')
                                {
                                    invalido = 1;
                                }
                                //Igual es para que no se salga del rango
                                if (i == 7)
                                {
                                    i = Gfila + 1;
                                }
                                else
                                {
                                    i++;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Introduce coordenadas correctas", "Datos incorrectos");
                        return;
                    }
                    if (invalido == 0)
                    {
                        tablero[Gfila, Gcolumna] = ' ';
                        tablero[fila, columna] = 'm';
                        cambioJugador();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Movimiento incorrecto", "Datos incorrectos");
                        return;
                    }
                case 'R':
                    //Si es un movimiento de enroque y es posible un enroque del rey
                    if (enroque_jugador1[0] == true && ((fila == 7) && (columna == posiciones_jugador1[1, 1] || columna == posiciones_jugador1[2, 1])))
                    {
                        //Si quiere hacer un enroque con la torre de la izquierda
                        if (enroque_jugador1[1] == true && columna == posiciones_jugador1[1, 1])
                        {
                            //Si el rey esta por la derecha de la posición final de la torre
                            if (posiciones_jugador1[0, 1] >= 3)
                            {
                                //Si la torre esta por la derecha de la zona final del rey
                                if (posiciones_jugador1[1,1] > 2)
                                {
                                    for (i = posiciones_jugador1[0, 1]; i > 2; i--)
                                    {
                                        if (tablero[7, i] != ' ' && tablero[7,i] != 'R' && i != posiciones_jugador1[1,1])
                                        {
                                            MessageBox.Show("Enroque imposible de realizar");
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    for (i = posiciones_jugador1[0, 1]; i > posiciones_jugador1[1, 1]; i--)
                                    {
                                        if (tablero[7, i] != ' ' && tablero[7, i] != 'R')
                                        {
                                            MessageBox.Show("Enroque imposible de realizar");
                                            return;
                                        }
                                    }
                                }
                                
                            }
                            else
                            {
                                for (i = 3; i > posiciones_jugador1[1, 1]; i--)
                                {
                                    if (tablero[7, i] != ' ' && tablero[7, i] != 'R')
                                    {
                                        MessageBox.Show("Enroque imposible de realizar");
                                        return;
                                    }
                                }
                            }
                            enroque_jugador1[0] = false;
                            tablero[Gfila, Gcolumna] = ' ';
                            tablero[7, posiciones_jugador1[1, 1]] = ' ';
                            tablero[7, 3] = 'T';
                            tablero[7, 2] = 'R';
                            cambioJugador();
                        }//Si quiere hacer un enroque con la torre de la derecha
                        else if (enroque_jugador1[1] == true && columna == posiciones_jugador1[2, 1])
                        {
                            //Si el rey esta por la izquierda de la posición final de la torre
                            if (posiciones_jugador1[0, 1] <= 5)
                            {
                                //Si la torre esta por la izquierda de la zona final del rey
                                if (posiciones_jugador1[2, 1] < 6)
                                {
                                    for (i = posiciones_jugador1[0, 1]; i < 6; i++)
                                    {
                                        if (tablero[7, i] != ' ' && tablero[7, i] != 'R' && i != posiciones_jugador1[2, 1])
                                        {
                                            MessageBox.Show("Enroque imposible de realizar_A");
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    for (i = posiciones_jugador1[0, 1]; i < posiciones_jugador1[2, 1]; i++)
                                    {
                                        if (tablero[7, i] != ' ' && tablero[7, i] != 'R')
                                        {
                                            MessageBox.Show("Enroque imposible de realizar_B");
                                            return;
                                        }
                                    }
                                }

                            }
                            else
                            {
                                if (tablero[7, 5] != ' ')
                                {
                                    MessageBox.Show("Enroque imposible de realizar_C");
                                    return;
                                }
                            }
                            enroque_jugador1[0] = false;
                            tablero[Gfila, Gcolumna] = ' ';
                            tablero[7, posiciones_jugador1[2, 1]] = ' ';
                            tablero[7, 5] = 'T';
                            tablero[7, 6] = 'R';
                            cambioJugador();
                        }
                    } else if ((fila == Gfila - 1 || fila == Gfila || fila == Gfila + 1) && (columna == Gcolumna - 1 || columna == Gcolumna || columna == Gcolumna + 1))
                    {
                        if (tablero[fila, columna] == ' ' || tablero[fila, columna] == 'p' || tablero[fila, columna] == 't' || tablero[fila, columna] == 'a' || tablero[fila, columna] == 'c' || tablero[fila, columna] == 'r' || tablero[fila, columna] == 'm')
                        {
                            tablero[Gfila, Gcolumna] = ' ';
                            tablero[fila, columna] = 'R';
                            cambioJugador();
                        }
                        else
                        {
                            MessageBox.Show("Movimiento incorrecto", "Datos incorrectos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Introduce coordenadas correctas", "Datos incorrectos");
                        return;
                    }
                    return;
                case 'r':
                    //Si es un movimiento de enroque y es posible un enroque del rey
                    if (enroque_jugador2[0] == true && ((fila == 0) && (columna == posiciones_jugador2[1, 1] || columna == posiciones_jugador2[2, 1])))
                    {
                        //Si quiere hacer un enroque con la torre de la izquierda
                        if (enroque_jugador2[1] == true && columna == posiciones_jugador2[1, 1])
                        {
                            //Si el rey esta por la derecha de la posición final de la torre
                            if (posiciones_jugador2[0, 1] >= 3)
                            {
                                //Si la torre esta por la derecha de la zona final del rey
                                if (posiciones_jugador2[1, 1] > 2)
                                {
                                    for (i = posiciones_jugador2[0, 1]; i > 2; i--)
                                    {
                                        if (tablero[0, i] != ' ' && tablero[0, i] != 'r' && i != posiciones_jugador2[1, 1])
                                        {
                                            MessageBox.Show("Enroque imposible de realizar");
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    for (i = posiciones_jugador2[0, 1]; i > posiciones_jugador2[1, 1]; i--)
                                    {
                                        if (tablero[0, i] != ' ' && tablero[0, i] != 'r')
                                        {
                                            MessageBox.Show("Enroque imposible de realizar");
                                            return;
                                        }
                                    }
                                }

                            }
                            else
                            {
                                for (i = 3; i > posiciones_jugador2[1, 1]; i--)
                                {
                                    if (tablero[0, i] != ' ' && tablero[0, i] != 'r')
                                    {
                                        MessageBox.Show("Enroque imposible de realizar");
                                        return;
                                    }
                                }
                            }
                            enroque_jugador2[0] = false;
                            tablero[Gfila, Gcolumna] = ' ';
                            tablero[0, posiciones_jugador2[1, 1]] = ' ';
                            tablero[0, 3] = 't';
                            tablero[0, 2] = 'r';
                            cambioJugador();
                        }//Si quiere hacer un enroque con la torre de la derecha
                        else if (enroque_jugador2[1] == true && columna == posiciones_jugador2[2, 1])
                        {
                            //Si el rey esta por la izquierda de la posición final de la torre
                            if (posiciones_jugador2[0, 1] <= 5)
                            {
                                //Si la torre esta por la izquierda de la zona final del rey
                                if (posiciones_jugador2[2, 1] < 6)
                                {
                                    for (i = posiciones_jugador2[0, 1]; i < 6; i++)
                                    {
                                        if (tablero[0, i] != ' ' && tablero[0, i] != 'r' && i != posiciones_jugador2[2, 1])
                                        {
                                            MessageBox.Show("Enroque imposible de realizar_A");
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    for (i = posiciones_jugador2[0, 1]; i < posiciones_jugador2[2, 1]; i++)
                                    {
                                        if (tablero[0, i] != ' ' && tablero[0, i] != 'r')
                                        {
                                            MessageBox.Show("Enroque imposible de realizar_B");
                                            return;
                                        }
                                    }
                                }

                            }
                            else
                            {
                                if (tablero[0, 5] != ' ')
                                {
                                    MessageBox.Show("Enroque imposible de realizar_C");
                                    return;
                                }
                            }
                            enroque_jugador2[0] = false;
                            tablero[Gfila, Gcolumna] = ' ';
                            tablero[0, posiciones_jugador2[2, 1]] = ' ';
                            tablero[0, 5] = 't';
                            tablero[0, 6] = 'r';
                            cambioJugador();
                        }
                    }else if ((fila == Gfila - 1 || fila == Gfila || fila == Gfila + 1) && (columna == Gcolumna - 1 || columna == Gcolumna || columna == Gcolumna + 1))
                    {
                        if (tablero[fila, columna] == ' ' || tablero[fila, columna] == 'P' || tablero[fila, columna] == 'T' || tablero[fila, columna] == 'A' || tablero[fila, columna] == 'C' || tablero[fila, columna] == 'R' || tablero[fila, columna] == 'M')
                        {
                            tablero[Gfila, Gcolumna] = ' ';
                            tablero[fila, columna] = 'r';
                            cambioJugador();
                        }
                        //Si es un movimiento de enroque y es posible un enroque del rey
                        else if (enroque_jugador2[0] == true && (fila == 0 && (columna == 2 || columna == 6)))
                        {
                            //Si quiere hacer un enroque con la torre de la izquierda
                            if (enroque_jugador2[1] == true && columna == 2)
                            {
                                if (tablero[0, 3] == ' ' && tablero[0, 2] == ' ' && tablero[0, 1] == ' ')
                                {
                                    enroque_jugador2[0] = false;
                                    tablero[Gfila, Gcolumna] = ' ';
                                    tablero[0, 0] = ' ';
                                    tablero[0, 3] = 't';
                                    tablero[fila, columna] = 'r';
                                    cambioJugador();
                                }

                            }//Si quiere hacer un enroque con la torre de la derecha
                            else if (enroque_jugador2[1] == true && columna == 6)
                            {
                                if (tablero[0, 5] == ' ' && tablero[0, 6] == ' ')
                                {
                                    enroque_jugador2[0] = false;
                                    tablero[Gfila, Gcolumna] = ' ';
                                    tablero[0, 7] = ' ';
                                    tablero[0, 5] = 't';
                                    tablero[fila, columna] = 'r';
                                    cambioJugador();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Movimiento incorrecto", "Datos incorrectos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Introduce coordenadas correctas", "Datos incorrectos");
                        return;
                    }
                    return;
                default:
                    MessageBox.Show("Ha ocurrido un error inesperado", "Error no esperado");
                    break;
            }
        }

        //Actualizar el tablero cada turno
        void dibujarTablero()
        {
            int i, y;
            char ficha = ' ';
            board.Text = "";
            if (dibujo)
            {
                for (i = 0; i < 8; i++)
                {
                    for (y = 0; y < 8; y++)
                    {
                        ficha = fichas(i, y);

                        if (tablero[i, y] == ' ')
                        {
                            board.Text = board.Text + " ";
                        }
                        board.Text = board.Text + ficha + "  ";
                        if (tablero[i, y] == ' ' && y <= 3)
                        {
                            board.Text = board.Text + " ";
                        }
                    }
                    board.Text = board.Text + "\n";
                }
            }
            else
            {
                for (i = 0; i < 8; i++)
                {
                    for (y = 0; y < 8; y++)
                    {
                        ficha = fichas(i, y);

                            switch (y)
                            {
                                case 0:
                                if (tablero[i, y] == ' ')
                                {
                                    board.Text = board.Text + " " + ficha;
                                }
                                else
                                {

                                    board.Text = board.Text + " ";
                                    board.Text = board.Text + ficha;
                                }
                                break;
                                case 1:
                                if (tablero[i, y] == ' ')
                                {
                                    board.Text = board.Text + "  " + ficha;
                                }
                                else
                                {

                                    board.Text = board.Text + "  ";
                                    board.Text = board.Text + ficha;
                                }
                                break;
                                case 2:
                                if (tablero[i, y] == ' ')
                                {
                                    board.Text = board.Text + "  " + ficha;
                                }
                                else
                                {

                                    board.Text = board.Text + "  ";
                                    board.Text = board.Text + ficha;
                                }
                                break;
                                case 3:
                                if (tablero[i, y] == ' ')
                                {
                                    board.Text = board.Text + "  " + ficha;
                                }
                                else
                                {

                                    board.Text = board.Text + "  ";
                                    board.Text = board.Text + ficha;
                                }
                                break;
                                case 4:
                                if (tablero[i, y] == ' ')
                                {
                                    board.Text = board.Text + "  " + ficha;
                                }
                                else
                                {

                                    board.Text = board.Text + "  ";
                                    board.Text = board.Text + ficha;
                                }
                                break;
                                case 5:
                                if (tablero[i, y] == ' ')
                                {
                                    board.Text = board.Text + "  " + ficha;
                                }
                                else
                                {

                                    board.Text = board.Text + "  ";
                                    board.Text = board.Text + ficha;
                                }
                                break;
                                case 6:
                                if (tablero[i, y] == ' ')
                                {
                                    board.Text = board.Text + "  " + ficha;
                                }
                                else
                                {

                                    board.Text = board.Text + "  ";
                                    board.Text = board.Text + ficha;
                                }
                                break;
                                case 7:
                                if (tablero[i, y] == ' ')
                                {
                                    board.Text = board.Text + "  " + ficha;
                                }
                                else
                                {

                                    board.Text = board.Text + "  ";
                                    board.Text = board.Text + ficha;
                                }
                                break;
                            }
                    }
                    board.Text = board.Text + "\n";
                }
            }
        }

        //Cambia la coordenada del número poniendo los valores descendientemente
        int arregloFila(int numero)
        {
            int fila;
            switch (numero)
            {
                case 1:
                    fila = 7;
                    break;
                case 2:
                    fila = 6;
                    break;
                case 3:
                    fila = 5;
                    break;
                case 4:
                    fila = 4;
                    break;
                case 5:
                    fila = 3;
                    break;
                case 6:
                    fila = 2;
                    break;
                case 7:
                    fila = 1;
                    break;
                case 8:
                    fila = 0;
                    break;
                default:
                    fila = 0;
                    break;
            }
            return fila;
        }

        //Cambia el char de una ficha por el respectivo carácter unicode de una ficha de ajedrez
        char fichas(int i, int y)
        {
            char ficha = tablero[i, y];

            if (dibujo)
            {

                switch (tablero[i, y])
                {

                    case ' ':
                        ficha = '\u2500';
                        break;
                    case 't':
                        ficha = '\u265C';
                        break;
                    case 'c':
                        ficha = '\u265E';
                        break;
                    case 'a':
                        ficha = '\u265D';
                        break;
                    case 'r':
                        ficha = '\u265A';
                        break;
                    case 'm':
                        ficha = '\u265B';
                        break;
                    case 'p':
                        ficha = '\u265F';
                        break;
                    case 'T':
                        ficha = '\u2656';
                        break;
                    case 'C':
                        ficha = '\u2658';
                        break;
                    case 'A':
                        ficha = '\u2657';
                        break;
                    case 'R':
                        ficha = '\u2654';
                        break;
                    case 'M':
                        ficha = '\u2655';
                        break;
                    case 'P':
                        ficha = '\u2659';
                        break;
                    default:
                        ficha = 'e';
                        MessageBox.Show("Ha ocurrido un error al dibujar el tablero");
                        break;
                }
            }
            else
            {
                if (ficha == ' ')
                {
                    ficha = '\u2500';
                }
            }
            return ficha;
        }

        //Cancela la selección de una ficha para poder elegir otra
        private void Cancel_Click(object sender, EventArgs e)
        {
            datosficha.Text = "Ficha: ";
            informacion.Text = "Se ha cancelado la selección";
            btnSelect.Enabled = true;
            mover.Enabled = false;
        }

        //Controla todo cuando un jugador termina su turno (dibujar tablero, activar botón, cambio jugador, etc)
        void cambioJugador()
        {
            btnSelect.Enabled = true;
            mover.Enabled = false;
            dibujarTablero();

            if (enroque_jugador1[0] == true)
            {
                if (tablero[posiciones_jugador1[1, 0], posiciones_jugador1[1, 1]] != 'T')
                {
                    enroque_jugador1[1] = false;
                }
                if (tablero[posiciones_jugador1[2, 0], posiciones_jugador1[2, 1]] != 'T')
                {
                    enroque_jugador1[2] = false;
                }
                if (tablero[posiciones_jugador1[0, 0], posiciones_jugador1[0, 1]] != 'R')
                {
                    enroque_jugador1[0] = false;
                }
                if(enroque_jugador1[1] == false && enroque_jugador1[2] == false)
                {
                    enroque_jugador1[0] = false;
                }
            }
            if (enroque_jugador2[0] == true)
            {
                if (tablero[posiciones_jugador2[1, 0], posiciones_jugador2[1, 1]] != 't')
                {
                    enroque_jugador2[1] = false;
                }
                if (tablero[posiciones_jugador2[2, 0], posiciones_jugador2[2, 1]] != 't')
                {
                    enroque_jugador2[2] = false;
                }
                if (tablero[posiciones_jugador2[0, 0], posiciones_jugador2[0, 1]] != 'r')
                {
                    enroque_jugador2[0] = false;
                }
                if (enroque_jugador2[1] == false && enroque_jugador2[2] == false)
                {
                    enroque_jugador2[0] = false;
                }
            }
            if (jugador)
            {
                player1.Text = "     Jugador 1";
                player2.Text = "-----Jugador 2-----";
                jugador = false;
                return;
            }
            else
            {
                player1.Text = "-----Jugador 1-----";
                player2.Text = "     Jugador 2";
                jugador = true;
                return;
            }
        }

        //Botón de opciones que llama al click derecho
        private void configuration_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        //Variante jubilado
        private void jubiladoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tablero = new char[8, 8]
            { {' ',' ',' ',' ','r',' ',' ',' '},
              {'p','p','p','p','p','p','p','p'},
              {' ',' ',' ',' ',' ',' ',' ',' '},
              {' ',' ',' ',' ',' ',' ',' ',' '},
              {' ',' ',' ',' ',' ',' ',' ',' '},
              {' ',' ',' ',' ',' ',' ',' ',' '},
              {'P','P','P','P','P','P','P','P'},
              {' ',' ',' ',' ','R',' ',' ',' '},};

            jugador = true;
            //Arrays para saber si es posible enrocar rey/torreI/torreD
            enroque_jugador1 = new bool[3] { false, true, true };
            enroque_jugador2 = new bool[3] { false, true, true };
            posiciones_jugador1 = new int[3, 2] { { 7, 4 }, { 7, 0 }, { 7, 7 } };
            posiciones_jugador2 = new int[3, 2] { { 0, 4 }, { 0, 0 }, { 0, 7 } };

            datosficha.Text = "Ficha: ";
            mover.Enabled = false;
            btnSelect.Enabled = true;
            dibujarTablero();
        }
        //Variante mariposa
        private void mariposaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tablero = new char[8, 8]
            { {'t','c','a','m','r','a','c','t'},
              {'p',' ',' ',' ',' ',' ',' ','p'},
              {' ','p',' ',' ',' ',' ','p',' '},
              {' ',' ','p','P','P','p',' ',' '},
              {' ',' ','P','p','p','P',' ',' '},
              {' ','P',' ',' ',' ',' ','P',' '},
              {'P',' ',' ',' ',' ',' ',' ','P'},
              {'T','C','A','M','R','A','C','T'},};

            jugador = true;
            //Arrays para saber si es posible enrocar rey/torreI/torreD
            enroque_jugador1 = new bool[3] { true, true, true };
            enroque_jugador2 = new bool[3] { true, true, true };
            posiciones_jugador1 = new int[3, 2] { { 7, 4 }, { 7, 0 }, { 7, 7 } };
            posiciones_jugador2 = new int[3, 2] { { 0, 4 }, { 0, 0 }, { 0, 7 } };

            datosficha.Text = "Ficha: ";
            mover.Enabled = false;
            btnSelect.Enabled = true;
            dibujarTablero();
        }
        //Variante arriba-abajo
        private void arribaabajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tablero = new char[8, 8]
            { {'T','C','A','M','R','A','C','T'},
              {'P','P','P','P','P','P','P','P'},
              {' ',' ',' ',' ',' ',' ',' ',' '},
              {' ',' ',' ',' ',' ',' ',' ',' '},
              {' ',' ',' ',' ',' ',' ',' ',' '},
              {' ',' ',' ',' ',' ',' ',' ',' '},
              {'p','p','p','p','p','p','p','p'},
              {'t','c','a','m','r','a','c','t'},};

            jugador = true;
            //Arrays para saber si es posible enrocar rey/torreI/torreD
            enroque_jugador1 = new bool[3] { true, true, true };
            enroque_jugador2 = new bool[3] { true, true, true };
            posiciones_jugador1 = new int[3, 2] { { 0, 4 }, { 0, 0 }, { 0, 7 } };
            posiciones_jugador2 = new int[3, 2] { { 7, 4 }, { 7, 0 }, { 7, 7 } };

            datosficha.Text = "Ficha: ";
            mover.Enabled = false;
            btnSelect.Enabled = true;
            dibujarTablero();
        }
        //Variante fischer
        private void fischerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Variante no disponible");
        }
        //Variante transcendental
        private void transcendentalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Variante no disponible");
        }
        //Variante dunsany
        private void dunsanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tablero = new char[8, 8]
            { {'t','c','a','m','r','a','c','t'},
              {'p','p','p','p','p','p','p','p'},
              {' ',' ',' ',' ',' ',' ',' ',' '},
              {' ',' ',' ',' ',' ',' ',' ',' '},
              {'P','P','P','P','P','P','P','P'},
              {'P','P','P','P','P','P','P','P'},
              {'P','P','P','P','P','P','P','P'},
              {'P','P','P','P','P','P','P','P'},};

            jugador = true;
            //Arrays para saber si es posible enrocar rey/torreI/torreD
            enroque_jugador1 = new bool[3] { false, true, true };
            enroque_jugador2 = new bool[3] { true, true, true };
            posiciones_jugador1 = new int[3, 2] { { 7, 4 }, { 7, 0 }, { 7, 7 } };
            posiciones_jugador2 = new int[3, 2] { { 0, 4 }, { 0, 0 }, { 0, 7 } };

            datosficha.Text = "Ficha: ";
            mover.Enabled = false;
            btnSelect.Enabled = true;
            dibujarTablero();
        }
        //Variante Juego de peones
        private void juegoDePeonesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tablero = new char[8, 8]
            { {'t','c','a','m','r','a','c','t'},
              {'p','p','p','p','p','p','p','p'},
              {' ',' ',' ',' ',' ',' ',' ',' '},
              {' ',' ',' ',' ',' ',' ',' ',' '},
              {' ',' ','P','P','P','P',' ',' '},
              {' ','P','P',' ',' ','P','P','P'},
              {'P','P','P','P','P','P','P','P'},
              {'T','C','A',' ','R','A','C','T'},};

            jugador = true;
            //Arrays para saber si es posible enrocar rey/torreI/torreD
            enroque_jugador1 = new bool[3] { true, true, true };
            enroque_jugador2 = new bool[3] { true, true, true };
            posiciones_jugador1 = new int[3, 2] { { 7, 4 }, { 7, 0 }, { 7, 7 } };
            posiciones_jugador2 = new int[3, 2] { { 0, 4 }, { 0, 0 }, { 0, 7 } };

            datosficha.Text = "Ficha: ";
            mover.Enabled = false;
            btnSelect.Enabled = true;
            dibujarTablero();
        }
        //Variante revuelta de campesinps
        private void revueltaDeCampesinosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tablero = new char[8, 8]
            { {' ','c','c',' ','r','c','c',' '},
              {' ',' ',' ',' ','p',' ',' ',' '},
              {' ',' ',' ',' ',' ',' ',' ',' '},
              {' ',' ',' ',' ',' ',' ',' ',' '},
              {' ',' ',' ',' ',' ',' ',' ',' '},
              {' ',' ',' ',' ',' ',' ',' ',' '},
              {'P','P','P','P','P','P','P','P'},
              {' ',' ',' ',' ','R',' ',' ',' '},};

            jugador = true;
            //Arrays para saber si es posible enrocar rey/torreI/torreD
            enroque_jugador1 = new bool[3] { false, true, true };
            enroque_jugador2 = new bool[3] { false, true, true };
            posiciones_jugador1 = new int[3, 2] { { 7, 4 }, { 7, 0 }, { 7, 7 } };
            posiciones_jugador2 = new int[3, 2] { { 0, 4 }, { 0, 0 }, { 0, 7 } };

            datosficha.Text = "Ficha: ";
            mover.Enabled = false;
            btnSelect.Enabled = true;
            dibujarTablero();
        }
        //Variante ¡débil!
        private void débilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tablero = new char[8, 8]
            { {'c','c','c','c','r','c','c','c'},
              {'p','p','p','p','p','p','p','p'},
              {' ',' ','p',' ',' ','p',' ',' '},
              {' ','p','p','p','p','p','p',' '},
              {' ',' ',' ',' ',' ',' ',' ',' '},
              {' ',' ',' ',' ',' ',' ',' ',' '},
              {'P','P','P','P','P','P','P','P'},
              {'T','C','A','M','R','A','C','T'},};

            jugador = true;
            //Arrays para saber si es posible enrocar rey/torreI/torreD
            enroque_jugador1 = new bool[3] { true, true, true };
            enroque_jugador2 = new bool[3] { false, true, true };
            posiciones_jugador1 = new int[3, 2] { { 7, 4 }, { 7, 0 }, { 7, 7 } };
            posiciones_jugador2 = new int[3, 2] { { 0, 4 }, { 0, 0 }, { 0, 7 } };

            datosficha.Text = "Ficha: ";
            mover.Enabled = false;
            btnSelect.Enabled = true;
            dibujarTablero();
        }
        //Ajedrez normal
        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tablero = new char[8, 8]
            { {'t','c','a','m','r','a','c','t'},
              {'p','p','p','p','p','p','p','p'},
              {' ',' ',' ',' ',' ',' ',' ',' '},
              {' ',' ',' ',' ',' ',' ',' ',' '},
              {' ',' ',' ',' ',' ',' ',' ',' '},
              {' ',' ',' ',' ',' ',' ',' ',' '},
              {'P','P','P','P','P','P','P','P'},
              {'T','C','A','M','R','A','C','T'},};

            jugador = true;
            //Arrays para saber si es posible enrocar rey/torreI/torreD
            enroque_jugador1 = new bool[3] { true, true, true };
            enroque_jugador2 = new bool[3] { true, true, true };
            posiciones_jugador1 = new int[3, 2] { { 7, 4 }, { 7, 0 }, { 7, 7 } };
            posiciones_jugador2 = new int[3, 2] { { 0, 4 }, { 0, 0 }, { 0, 7 } };

            datosficha.Text = "Ficha: ";
            mover.Enabled = false;
            btnSelect.Enabled = true;
            dibujarTablero();
        }


        //Ver tablero con piezas
        private void piezasUnicodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dibujo = true;
            dibujarTablero();
        }
        //Ver tablero con letras
        private void charToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dibujo = false;
            MessageBox.Show("No acabado");
            dibujarTablero();
        }

        //Cambiar modo ventana
        private void ventanaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle == System.Windows.Forms.FormBorderStyle.None)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            }
            else
            {
                MessageBox.Show("No acabado");
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            }
        }

        //Ayuda general
        private void generalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El jugador 1 maneja las fichas blancas(abajo), el jugador 2 maneja las fichas negras(arriba)," +
                " las reglas son las reglas normales del ajedrez, para elegir una ficha debes introducir las coordenadas en las" +
                " cajas de texto que estan arriba, el número es la fila y la letra la columna, una vez introducidas las coordenadas" +
                " tendrás que pulsar seleccionar, para seleccionar la ficha, si hay algún movimiento posible se activará el botón" +
                " de movimiento en el que volviendo a elegir las coordenadas, al pulsarlo si es un movimiento correcto se ejecutará" +
                " la acción, si se deseas cancelar la elección de la ficha simplemente podrás pulsar cancelar.\n\n Importante: Para" +
                " realizar un enroque, con el rey seleccionado se deberá introducir las coordenadas de la torre con la que se quiere" +
                " enrocar. ","Ayuda general");
        }

        private void variantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Las variantes son otras formas de jugar al ajedrez, las que podemos encontrar aqui se clasifican en" +
                " dos grupos:\n-Igualdad de fuerzas: En este grupo las fichas seran equivalentes para los dos jugadores, podemos" +
                " encontrar estas variantes:\n\t-Fischer: Esta variante se caracteriza por cambiar aleatoriamente la posición de" +
                " las fichas menos la de los peones, estando el rey siempre entre dos torres.\n\t-Trascendental: Esta variante es" +
                " exactamente igual que la de Fischer exceptuando a que la posición de las fichas aleatorias será siempre la misma" +
                ".\n\t-Arriba-Abajo: Este variante intercambia los lados de las fichas de los jugadores pero no el del tablero, por lo " +
                " que los peones estarán a un movimiento de \"ascender\".\n\t-Jubilado: En esta variante solo estan disponibles los" +
                " peones y el rey inicialmente.\n\t-Mariposa: Esta variante intercambia la posición de las fichas simétricamente " +
                "haciendo la forma de una mariposa. ¿?\n-Diferentes fuerzas: En este grupo las fichas no seran equivalentes para los" +
                " dos jugadores haciendo que uno obtenga ventaja (o no), podemos encontrar las siguientes variantes:\n\tDunsany:" +
                " Esta variante otorga al jugador 1: 32 peones y el jugador 2 las fichas normales.\n\tJuego de peones:" +
                " En esta variante se intercambia la reina del jugador 1 por 6 peones colocados simétricamente.\n\tRevuelta de " +
                "campesinos: Esta variante otorga al jugador 1: solo 8 peones y el rey y al jugador 2: 4 caballos, 1 peón y el rey." +
                "\n\t¡Débil!: En esta variante el jugador 1 jugará con las fichas normales, y el jugador 2 se le cambiarán las " +
                "fichas especiales menos el rey por caballos y se le otorgará 8 peones adicionales.");
        }
    }
}
