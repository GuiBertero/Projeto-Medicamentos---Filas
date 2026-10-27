using System.Collections.Generic;

public class Medicamentos
{
    private List<Medicamento> listaMedicamentos;

    public Medicamentos()
    {
        listaMedicamentos = new List<Medicamento>();
    }

    public void adicionar(Medicamento medicamento)
    {
        listaMedicamentos.Add(medicamento);
    }

    public bool deletar(Medicamento medicamento)
    {
        if (medicamento.qtdeDisponivel() != 0)
        {
            return false;
        }

        return listaMedicamentos.Remove(medicamento);
    }

    public Medicamento pesquisar(Medicamento medicamento)
    {
        foreach (Medicamento m in listaMedicamentos)
        {
            if (m.getId() == medicamento.getId())
            {
                return m;
            }
        }

        return new Medicamento();
    }

    public List<Medicamento> listar()
    {
        return listaMedicamentos;
    }
}
