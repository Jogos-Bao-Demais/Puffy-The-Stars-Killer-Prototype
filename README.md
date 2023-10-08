# Puffy-The-Stars-Killer-GM

### Vetor/Array em C++: O que são? Para que servem?

Neste tutorial introdutório de nossa seção de Vetores (ou Arrays), vamos dar início aos estudos desse importante assunto e ferramenta, que você usará muito, em seus programas de C++.  
  

## O que é um Array (ou vetor) ?

O array, também chamado de vetor, é tipo de estrutura de dados (coleção de dados), do mesmo tipo. Ou seja, é um modo existente de trabalharmos com várias quantidades de variáveis.  
  
Até o momento, estudamos apenas variáveis únicas, que recebem e armazenam uma única informação, como um número. É um bloquinho de memória reservado para guardar algum dado.  
  
No caso do array, ele é um grupo de variáveis do mesmo tipo. Quando declaramos um vetor, o C++ vai lá e reserva um bloco de memória bem grande, suficiente para caber várias variáveis, todos os endereços são vizinhos.  
  
Assim como as structs e classes, os arrays são estáticos, ou seja, durante a execução possuem o mesmo tamanho sempre.  
  
Inicialmente, vamos estudar os arrays ao estilo da linguagem C, baseado em ponteiros (que iremos estudar em breve). Mais na frente no nosso curso, na seção de STL (Standard Template Library), vamos conhecer os _vectors_, arrays como objetos completos e bem mais versáteis.  
  
Mas antes, precisamos entender um pouco mais sobre os arrays.  
  

![Para que servem os vetores](https://1.bp.blogspot.com/-xVUqdLCWNxs/Xlf84RUQngI/AAAAAAAAW0E/NmjEGFsoZgEF46Q_1LpKuIwGZmoKL5P-wCLcBGAsYHQ/s320/vetor-array-c%252B%252B.jpeg "O que são arrays")

Um array de uma dimensão, com 6 elementos (variáveis do mesmo tipo)

  

## Para que serve um vetor (ou array) ?

Imagine que você quer calcular a média de dois alunos da sua turma.  
Basta declarar duas variáveis: a e b, e fazer (a+b)/2  
Simples, né?  
  
E caso queira calcular a média de três alunos?  
Hora, é óbvio: (a+b+c)/3  
  
Bacana...e se quiser calcular a média de uma turma de 30 alunos?  
Vai declarar 30 variáveis e fazer: (a+b+c+d+e+f+g....)/30 ?  
Nem tem 30 letras no alfabeto.  
  
É aí que entra o conceito de array.  
Vamos simplesmente declarar um vetor de floats, por exemplo, de tamanho 30.  
Ou seja, 30 variáveis do tipo float, vizinhas de memória, serão alocadas em sua máquina, de uma vez só, ao criarmos esse array.  
  
Basicamente é para isso que serve um array: vamos aprender a declarar, inicializar, usar e manusear grandes blocos de informações de uma só vez, mexendo com 10, 10, mil ou 1 milhão de variáveis de uma vez só, de maneira bem automatizada e simples, através de arrays.
