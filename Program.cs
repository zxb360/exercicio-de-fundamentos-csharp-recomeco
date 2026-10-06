// ============================================================================
// 🍬 EXERCÍCIO PRÁTICO: SISTEMA DE ESTOQUE - DISTRIBUIDORA DE DOCES
// ============================================================================
// PRODUTOS PRINCIPAIS:
// 1. Cocada Tradicional
// 2. Pé de Moleque
// 3. Cocada de Maracujá
// 4. Pipoca Doce
// 5. Doce de Amendoim
// ============================================================================

Console.WriteLine("=================================================");
Console.WriteLine("🍬 DISTRIBUIDORA DE DOCES: CONTROLE DE ESTOQUE 🍬");
Console.WriteLine("=================================================");
Console.WriteLine();

// ----------------------------------------------------------------------------
// 🎯 DESAFIO 1: O ARRAY DE PRODUTOS
// ----------------------------------------------------------------------------
// CONCEITO:
// Arrays guardam múltiplos valores do mesmo tipo com tamanho fixo.
// Em C# moderno (.NET 8), você pode declarar com a sintaxe de coleção:
//   string[] frutas = ["Maçã", "Banana"];
// Ou a clássica:
//   string[] frutas = new string[] { "Maçã", "Banana" };
//
// SUA MISSÃO:
// 1. Declare um array de strings chamado 'produtos' contendo os 5 doces:
//    "Cocada Tradicional", "Pé de Moleque", "Cocada de Maracujá", "Pipoca Doce", "Doce de Amendoim"
// 2. Imprima na tela o total de tipos de doces usando a propriedade .Length
// 3. Imprima o primeiro produto (índice 0) e o último produto (índice 4 ou usando o índice reverso [^1])
// ----------------------------------------------------------------------------

// >>> DIGITE SEU CÓDIGO DO DESAFIO 1 AQUI ABAIXO <<<
string[] produtos = new string[] { "Cocada Tradicional", "Pé de Moleque", "Cocada de Maracujá", "Pipoca Doce", "Doce de Amendoim" };
Console.WriteLine($"Total de tipos de doces: {produtos.Length}");
Console.WriteLine($"Primeiro produto: {produtos[0]}");
Console.WriteLine($"Último produto: {produtos[^1]}"); // índice reverso


// ----------------------------------------------------------------------------
// 🎯 DESAFIO 2: QUANTIDADES E PREÇOS (ESCOLHA DOS TIPOS DE DADOS)
// ----------------------------------------------------------------------------
// CONCEITO:
// - Para quantidades inteiras: use 'int'.
// - Para dinheiro / valores financeiros: NUNCA use 'double' ou 'float'!
//   Eles usam aritmética binária de ponto flutuante e causam erros de dízima em centavos.
//   SEMPRE use 'decimal' (no C# sufixamos o número com 'm', ex: 3.50m).
//
// SUA MISSÃO:
// 1. Crie um array de inteiros chamado 'quantidades' com as unidades em estoque para cada um dos 5 doces:
//    Exemplo: 50, 35, 20, 100, 40
// 2. Crie um array de decimais chamado 'precos' com os preços de venda de cada um:
//    Exemplo: 4.50m, 3.00m, 5.50m, 2.50m, 3.75m
// ----------------------------------------------------------------------------

// >>> DIGITE SEU CÓDIGO DO DESAFIO 2 AQUI ABAIXO <<<

int[] quantidades = new int[] { 50, 35, 20, 100, 40 };
decimal[] precos = [4.50m, 3.00m, 5.50m, 2.50m, 3.75m ];


// ----------------------------------------------------------------------------
// 🎯 DESAFIO 3: LAÇO FOR E FORMATAÇÃO DE TEXTO INTERPOLADA
// ----------------------------------------------------------------------------
// CONCEITO:
// Para percorrer arrays paralelos pelo mesmo índice, usamos o laço 'for':
//   for (int i = 0; i < produtos.Length; i++) { ... }
//
// DICA DE FORMATAÇÃO:
// Em C#, a interpolação com $ permite formatar moeda automaticamente com :C
// Exemplo: $"{preco:C}" formata para moeda local (R$ 4,50).
//
// SUA MISSÃO:
// Use um laço 'for' para exibir no console a lista completa dos 5 doces no seguinte formato:
// "[1] Cocada Tradicional | Estoque: 50 un | Preço: R$ 4,50"
// "[2] Pé de Moleque     | Estoque: 35 un | Preço: R$ 3,00"
// ... e assim por diante.
// ----------------------------------------------------------------------------

// >>> DIGITE SEU CÓDIGO DO DESAFIO 3 AQUI ABAIXO <<<
for (int i = 0; i < produtos.Length; i++)
{
    Console.WriteLine($"""
    [{i + 1}] {produtos[i], -20} 
    Estoque: {quantidades[i]}un 
    Preço: {precos[i]:C}
    ----------------------------
    """);
}



// ----------------------------------------------------------------------------
// 🎯 DESAFIO 4: EVOLUINDO PARA OBJETOS (PARADIGMA PROFISSIONAL)
// ----------------------------------------------------------------------------
// CONCEITO:
// No dia a dia de uma empresa, NUNCA mantemos múltiplos arrays soltos (produtos, quantidades, precos).
// Se você ordenar um e esquecer do outro, o estoque quebra!
// Agrupamos tudo em um MODELO (Classe ou Record).
//
// Exemplo de record moderno no C# (imutável e conciso):
// public record Doce(string Nome, int Quantidade, decimal Preco);
//
// SUA MISSÃO:
// 1. Declare o record 'Doce' (pode ser no final do arquivo ou antes do seu uso).
// 2. Crie uma List<Doce> chamada 'estoqueDoces'.
// 3. Adicione os 5 doces nessa lista usando 'estoqueDoces.Add(new Doce(...))'
//    ou usando a inicialização direta de lista: List<Doce> estoque = [ ... ];
// ----------------------------------------------------------------------------

// >>> DIGITE SEU CÓDIGO DO DESAFIO 4 AQUI ABAIXO <<<

List<Doce> estoqueDoces = [
    new Doce("Cocada Tradicional", 50, 4.50m),
    new Doce("Pé de Moleque", 35, 3.00m),
    new Doce("Cocada de Maracujá", 20, 5.50m),
    new Doce("Pipoca Doce", 100, 2.50m),
    new Doce("Doce de Amendoim", 40, 3.75m)
];

estoqueDoces.Add(new Doce("Doce de Leite", 60, 4.00m)); // Exemplo de adição de mais um doce
Console.WriteLine("Estoque atualizado com mais um doce: Doce de Leite");

foreach (var doce in estoqueDoces)
{
    Console.WriteLine($"""
    Produto: {doce.Nome}, Estoque: {doce.Quantidade}un, Preço: {doce.Preco:C}
    """);
}
Console.WriteLine(estoqueDoces);


// ----------------------------------------------------------------------------
// 🎯 DESAFIO 5: LÓGICA DE NEGÓCIO E FOREACH
// ----------------------------------------------------------------------------
// CONCEITO:
// O laço 'foreach' percorre coleções diretamente sem precisar controlar índice 'i':
//   foreach (var doce in estoqueDoces) { ... }
//
// SUA MISSÃO:
// 1. Calcule o VALOR TOTAL de mercadorias no estoque da distribuidora (soma de Preco * Quantidade de todos os doces).
// 2. Encontre qual doce está com o MENOR estoque (o produto que precisa ser reposto com urgência).
// 3. Imprima no console o resumo final:
//    - "Valor total investido no estoque: R$ ..."
//    - "Produto com estoque crítico: [Nome] (restam apenas X unidades)"
// ----------------------------------------------------------------------------

// >>> DIGITE SEU CÓDIGO DO DESAFIO 5 AQUI ABAIXO <<<
int valorTotalEstoque = 0;

foreach (var doce in estoqueDoces)
{
    decimal valorTotal = doce.Preco * doce.Quantidade;
    valorTotalEstoque += (int)valorTotal;
    Console.WriteLine($"Valor total investido em {doce.Nome}: {valorTotal:C}");

        if (doce.Quantidade < 10)
        {
            Console.WriteLine($"Produto com estoque crítico: {doce.Nome} (restam apenas {doce.Quantidade} unidades)");
        }
}
Console.WriteLine($"Valor total do estoque: {valorTotalEstoque:C}");


Console.WriteLine("=================================================");
// ----------------------------------------------------------------------------
// Valor de vendas porcentagem em cada produto
// ----------------------------------------------------------------------------
// Verificar o valor inicial de cada produto e calcular o valor de venda com margens unicas de lucro
// para cada produto, e exibir o valor de venda final de cada produto com a porcentagem de lucro aplicada.

// "Cocada Tradicional", "Pé de Moleque", "Cocada de Maracujá", "Pipoca Doce", "Doce de Amendoim"
// ----------------------------------------------------------------------------
// Tabela de margens de lucro:
// Cocada Tradicional: 20%
// Pé de Moleque: 25%
// Cocada de Maracujá: 30%
// Pipoca Doce: 15%
// Doce de Amendoim: 10%

foreach (var doce in estoqueDoces)
{
    decimal margemLucro = 0;

    switch (doce.Nome)
    {
        case "Cocada Tradicional":
            margemLucro = 0.20m;
            break;
        case "Pé de Moleque":
            margemLucro = 0.25m;
            break;
        case "Cocada de Maracujá":
            margemLucro = 0.30m;
            break;
        case "Pipoca Doce":
            margemLucro = 0.15m;
            break;
        case "Doce de Amendoim":
            margemLucro = 0.10m;
            break;
    }

    decimal valorVenda = doce.Preco * (1 + margemLucro);
    Console.WriteLine($"""
    Produto: {doce.Nome},
    Valor de compra: {doce.Preco:C}
    Valor de venda: {valorVenda:C} 
    Preço de venda com lucro: {valorVenda - doce.Preco:C} 
    (Margem de lucro: {margemLucro:P})
    Total a vender: {valorVenda * doce.Quantidade:C}
    ========================================================
    """);
}
public record Doce(string Nome, int Quantidade, decimal Preco);