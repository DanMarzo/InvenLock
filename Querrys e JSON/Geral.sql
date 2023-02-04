SELECT * FROM Equipamentos

SELECT * FROM Funcionarios

SELECT * FROM ContatoFuncionarios

SELECT * FROM Funcionarios F
inner join ContatoFuncionarios C ON C.FuncionarioId = F.FuncionarioId



DELETE FROM Funcionarios WHERE FuncionarioId = '93612ac2-92e7-403e-a0f0-3b3b23869f7d'

DELETE FROM ContatoFuncionarios WHERE FuncionarioId = '93612ac2-92e7-403e-a0f0-3b3b23869f7d'

SELECT * FROM Ocorrencias

SELECT * FROM ConsertoEquips

sp_help Funcionarios
sp_help Equipamentos
sp_help Ocorrencias
sp_help ConsertoEquips
                       