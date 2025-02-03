Avaliação técnica Mouts TI - Guilherme Rodrigues

Para rodar o projeto, é necessário setar o Ambev.DeveloperEvaluation.WebApi como default e executar.
![image](https://github.com/user-attachments/assets/10981dc7-a55c-491b-9600-2ba055d5295c)

O banco de dados está configurado para rodar localmente (SQLite), portanto, não é necessário realizar nenhuma configuração.
Ao executar o projeto, a API estará disponivel pela documentação do Swagger. conforme abaixo:

![image](https://github.com/user-attachments/assets/7a51296c-3e74-414a-9b92-c5e1f03d8e1b)

![image](https://github.com/user-attachments/assets/e142f562-c5cd-4168-88bf-6bacad2015e0)

Não é necessário rodar migration, pois o banco está local no projeto, conforme print:
![image](https://github.com/user-attachments/assets/4eb053fd-6b1f-4d0f-8432-43bd7b091cf5)

Foram realizados testes unitários para a criação de Produto e Carrinho, além do fechamento de Carrinho.
Houve a criação de mais duas coberturas referentes as regras de negócio constante no desafio:
  Restrictions:
     - Maximum limit: 20 items per product
     - No discounts allowed for quantities below 4 items

Segue o print constante no código:
![image](https://github.com/user-attachments/assets/147a2300-b092-4cf3-ae5a-efe58770cbc2)


Permaneço à disposição para qualquer explicação.

guilhermejonathan@hotmail.com
