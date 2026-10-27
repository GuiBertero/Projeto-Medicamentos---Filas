using System;
using System.Collections.Generic;

public class Medicamento
{
    private int id;
    private string nome;
    private string laboratorio;
    private Queue<Lote> lotes;

    public Medicamento()
    {
        id = 0;
        nome = "";
        laboratorio = "";
        lotes = new Queue<Lote>();
    }

    public Medicamento(int id, string nome, string laboratorio)
    {
        this.id = id;
        this.nome = nome;
        this.laboratorio = laboratorio;
        lotes = new Queue<Lote>();
    }

    public int getId()
    {
        return id;
    }

    public string getNome()
    {
        return nome;
    }

    public string getLaboratorio()
    {
        return laboratorio;
    }

    public Queue<Lote> getLotes()
    {
        return lotes;
    }

    public int qtdeDisponivel()
    {
        int total = 0;

        foreach (Lote lote in lotes)
        {
            total += lote.getQtde();
        }

        return total;
    }

    public void comprar(Lote lote)
    {
        lotes.Enqueue(lote);
    }

    public bool vender(int qtde)
    {
        if (qtdeDisponivel() < qtde)
        {
            return false;
        }

        int quantidadeRestante = qtde;

        while (quantidadeRestante > 0)
        {
            Lote lote = lotes.Peek();

            if (lote.getQtde() <= quantidadeRestante)
            {
                quantidadeRestante -= lote.getQtde();

                lotes.Dequeue();
            }
            else
            {
                lote.setQtde(lote.getQtde() - quantidadeRestante);

                quantidadeRestante = 0;
            }
        }

        return true;
    }

    public override string ToString()
    {
        return id + "-" +
               nome + "-" +
               laboratorio + "-" +
               qtdeDisponivel();
    }

    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Medicamento))
        {
            return false;
        }

        Medicamento medicamento = (Medicamento)obj;

        return id == medicamento.id;
    }

    public override int GetHashCode()
    {
        return id.GetHashCode();
    }
}
