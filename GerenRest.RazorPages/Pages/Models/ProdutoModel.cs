namespace GerenRest.RazorPages.Models {
    public class ProdutoModel {
        public int? ProdutoID { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public float? Preco { get; set; }
        public List<CategoriaModel>? Categoria { get; set; }
    }
}