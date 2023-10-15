using System.Runtime.Intrinsics.X86;


public interface IGrafico
{
    public bool Mover(int x, int y);
    

    public void Dibujar();

}

public class Punto : IGrafico
{
    public int x { get; set; }
    public int y { get; set; }

  
 
    void PuntoMethod(int x, int y)
    {
        Console.WriteLine("");
    }

    public void Dibujar()
    {
        throw new NotImplementedException();
    }

    public bool Mover(int x, int y)
    {
        throw new NotImplementedException();
    }
}

public class GraficoCompuesto : IGrafico
{
    private List<IGrafico> GraphicList;
    public bool Mover(int x, int y)
    {
        throw new NotImplementedException();
    }

    public void Dibujar()
    {
        throw new NotImplementedException();
    }
}

public class Circulo : Punto
{
    private int radio { get; set; }

    void CrearCirculo(int x, int y, int radio)
    {
        Console.WriteLine("");
    }
}

public class Rectangulo : Punto
{
    private int ancho { get; set; }
    private int alto { get; set; }

    void CrearRectangulo(int x, int y, int ancho, int alto)
    {
        Console.WriteLine("");
    }
}