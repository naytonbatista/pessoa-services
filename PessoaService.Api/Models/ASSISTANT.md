### Regras de código

- Sempre crie uma propriedade Id do tipo int para cada Model dessa pasta
- Quando uma propriedade string non-nullable for criada, a inicialize com `string.Empty`
- Sempre use as melhores práticas para tipos, incluindo encontrar o melhor tipo para propriedade
- Toda classe dessa pasta deve ser `sealed`
- Toda classe dessa pasta deve ter as propriedades `CreatedAt` e `UpdatedAt`
- Use `#region` para agrupar **Propriedades**, **Chaves** e **Propriedades de Navegação**
- Propriedades como `Id` serão as únicas consideradas como **Chaves**
- Propriedades como `PessoaId` serão consideradas como **Propriedades de Navegação**

### Regras para Enums
- Sempre use o prefixo `E` para enums
- Os enums sempre ficarão na pasta `./Enums`