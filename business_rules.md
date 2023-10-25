# Observação: Regras para Atualização de Objetos

## Companies - {cnpj}

- Ao realizar a criação da empresa, é necessário um CNPJ válido e único.

## Department - {Id, companiesCnpj}

- Ao criar um departamento, é necessário vincular a ele o CNPJ de uma empresa existente.

- Não será possível (via atualização):
  - Vincular esse departamento a outra empresa.
  - Alterar o seu Id.
  - Possuir dois departamentos com o mesmo líder.

## Employee - {Id, cpf, email, phone, departmentId, companiesId}

- Ao criar um funcionário, é necessário vinculá-lo a um departamento pertencente à empresa com aquele CNPJ.

- Não será possível (via atualização):
  - Alterar o CPF.
  - Vincular mais de um departamento.
  - Atribuir um departamento de outra empresa ao funcionário (caso aconteça, o Id do departamento ou CNPJ da empresa será automaticamente alterado para o correto).

## Task - {TaskId}

- Ao criar uma tarefa, é necessário vinculá-la a um departamento.

- Não será possível (via atualização):
  - Alterar o departamento vinculado à tarefa (caso aconteça, o Id do departamento será automaticamente alterado para o correto).

## EmployeeTask - {TaskId, EmployeeId}

- Para atribuir uma tarefa ao funcionário, ambos devem pertencer ao mesmo departamento e, portanto, ser da mesma empresa.

- Não será possível realizar alterações. Para atualizar, é necessário excluir a atribuição e criar uma nova.
