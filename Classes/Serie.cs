using System;
using Cadastro.Enum;

namespace Cadastro.Classes
{   
    // Atributos
    public class Serie : EntidadeBase
    {
        private Genero Genero{get; set;}
        private string Titulo{get; set;}
        private string Descrition{get; set;}
        private int Ano{get; set;}
        private string Elenco{get; set;}
        private string Nacionalidade{get; set;}
        private bool Excluido{get; set;}

    // Construtor
        public Serie(int id, Genero genero, string titulo, string descrition, 
        int ano, string elenco, string nacionalidade)
        {
            this.id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descrition = descrition;
            this.Ano = ano;
            this.Elenco = elenco;
            this.Nacionalidade = nacionalidade;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descrition + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;
            retorno += "Elenco: " + this.Elenco + Environment.NewLine;
            retorno += "Nacionalidade: " + this.Nacionalidade + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;

            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.id;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }

        public bool RetornaExcluido()
        {
            return this.Excluido;
        }

    }
}