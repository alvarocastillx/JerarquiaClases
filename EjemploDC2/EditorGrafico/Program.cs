using System.Runtime.Intrinsics.X86;


class Programa
{
    static void Main(string[] args)
    {
        //Crear punto:
        Punto punto1 = new Punto(5,5); // Se crea el punto
        Console.WriteLine(punto1.Dibujar()); // Se dibuja
        punto1.Mover(7, 7); //Se mueve
        Console.WriteLine(punto1.Dibujar()); // Se vuelve a dibujar
    
        //Crear circulo
        Circulo circulo1 = new Circulo(40, 50, 20);
        Console.WriteLine(circulo1.Dibujar());
        circulo1.Mover(20, 20);
        Console.WriteLine(circulo1.Dibujar());
    
        //Crear rectángulo
        Rectangulo rectangulo1 = new Rectangulo(20, 20, 20, 20);
        Console.WriteLine(rectangulo1.Dibujar());


        //Crear gráfico compuesto:
        //GraficoCompuesto graficoCompuesto = new GraficoCompuesto();
        //graficoCompuesto.AgregarGrafico(punto1);
        //Console.WriteLine(graficoCompuesto.Dibujar());



    }
}


public interface IGrafico
{
    public bool Mover(int x, int y);


    string Dibujar();

}

public class Punto : IGrafico
{   
    private int _x;
    private int _y;
    public int x
    {
        get { return _x;}
        set
        {
            if (_x <= 800)
            {
                _x = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }

    public int y
    {
        get { return _y; }
        set
        {
            if (y <= 600)
            {
                _y = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }

    public Punto(int x,int y)
    {
        this.x = x;
        this.y = y;
    }


    void PuntoMethod(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public virtual string Dibujar()
    {
        return "Punto dibujado: "  + this.x + " : " + this.y;
    }

    public bool Mover(int x, int y)
    {
        if (x <= 800 && y<= 600)
        {
            this.x = x;
            this.y = y;
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class GraficoCompuesto : IGrafico
{
    private List<IGrafico> GraphicList;
    public bool Mover(int x, int y)
    {
        if (x <= 800 && y <= 600)
        {
            for (int i = 0; i < GraphicList.Count; i++)
            {
                GraphicList[i].Mover(x, y);
            }

            return true;
        }
        else
            return false;
    }

    public string Dibujar()
    {
        string GraficosDibujados = "";
        for (int i = 0; i < GraphicList.Count; i++)
        {
            GraficosDibujados += GraphicList[i].Dibujar() + "/n";
        }
        Console.WriteLine("Jesuli" + GraficosDibujados);
        return GraficosDibujados;
    }

    public void AgregarGrafico(IGrafico grafico)
    {
        GraphicList.Add(grafico);
    }
}

public class Circulo : Punto
{
    private int _radio;
    private int radio
    {
        get { return _radio;}
        set
        {
            bool radio_x = false;
            bool radio_y = false;
            if (this.x-radio >= 0 && this.x+radio <= 800)
            {
                radio_x = true;
            }

            if (this.y - radio >= 0 && this.y + radio <= 600)
            {
                radio_y = true;
            }

            if (radio_x && radio_y)
            {
                _radio = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
    

    void CrearCirculo(int x, int y, int radio)
    {
        this.x = x;
        this.y = y;
        this.radio = radio;
    }

    public Circulo(int x, int y,int radio) : base(x, y)
    {
        this.radio = radio;
        this.x = x;
        this.y = y;
    }

    public override string Dibujar()
    {
        return "Circulo: radio:" + this.radio + " x:" + this.x + " y:" + this.y;
    }
}

public class Rectangulo : Punto
{
    private int ancho
    {
        get { return ancho;}
        set
        {
            if (ancho <= 800)
            {
                this.ancho = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        
    }
    private int alto {
        get { return alto;}
        set
        {
            if (alto <= 600)
            {
                this.alto = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        
    }

    void CrearRectangulo(int x, int y, int ancho, int alto)
    {
        this.x = x;
        this.y = y;
        this.ancho = ancho;
        this.alto = alto;
    }

    public Rectangulo(int x, int y,int ancho, int alto) : base(x, y)
    {
    }

    public override string Dibujar()
    {
        return "Circulo: ancho:" + this.ancho + " alto:" + this.alto + " x:" + this.x + " y:" + this.y;
    }
}