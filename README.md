Este projeto foi desenvolvido para praticar os conceitos de Clean Architecture pelo curso do Macorati.

Com ele é possível criar diferentes categorias e produtos, edita-los e remove-los. O projeto também contém 
sistema de login.

Ele foi dividido em 7 camadas, são elas:
    -CleanArch.Domain:
        Responsavel por guardar e validar as principais regras de negocio, não depende de outros projetos para funcionar.

    -CleanArch.Domain.Test:
        Testa as regras de negócio da camada Domain. 

    -CleanArch.Application:
        Camada responsável pelos serviços, guardando regras de negocios mais complexas. Depende apenas do Domain.

    -CleanArch.Infra.Data:
        Guarda as informações necessárias de infraestrutura, implementando o acesso ao banco e outros detalhes.

    -CleanArch.Infra.IoC:
        Responsável por registrar os serviços das camadas, mantendo o desacoplamento entre elas.

    -CleanArch.WebUi
        Projeto MVC criado para testar o projeto inteiro.

    -CleanArch.API:
        Camada responsável por expor a API através de Endpoints.



