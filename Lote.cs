using System;

public class Lote
{
    private int id;
    private int qtde;
    private DateTime venc;

    public Lote()
    {
        id = 0;
        qtde = 0;
        venc = DateTime.MinValue;
    }

    public Lote(int id, int qtde, DateTime venc)
    {
        this.id = id;
        this.qtde = qtde;
        this.venc = venc;
    }

    public int getId()
    {
        return id;
    }

    public int getQtde()
    {
        return qtde;
    }

    public DateTime getVenc()
    {
        return venc;
    }

    public void setQtde(int qtde)
    {
        this.qtde = qtde;
    }

    public override string ToString()
    {
        return id + "-" +
               qtde + "-" +
               venc.ToString("dd/MM/yyyy");
    }
}
