namespace APILivro.Model
{
    public class Livro
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Titulo { get; set; }
        public string Edicao { get; set; }
        public int AnoEdicao { get; set; }
        public int Paginas { get; set; }
        public string Editor { get; set; }
        public string Autor { get; set; }
        public string Descricao { get; set; }  
    }
}
