# Guia Rápido de Git e GitHub para Iniciantes - Senac SP

Este tutorial mostra o fluxo básico de trabalho com Git e GitHub, usando comandos essenciais para o dia a dia de quem está começando no desenvolvimento.

## Fluxo dos 3 Estágios do Git

O Git trabalha com três áreas principais:

- **Código Local**: Onde você edita seus arquivos.
- **Staging (Área de Preparação)**: Onde você prepara os arquivos para serem salvos.
- **Repositório Local**: Onde ficam os commits feitos na sua máquina.
- **Repositório Remoto (GitHub)**: Onde você armazena seu código na nuvem.

### Ilustração do Fluxo

```mermaid
flowchart LR
    A[Trabalhe nos arquivos locais] --> B[git add .]
    B --> C[Staging Area]
    C --> D[git commit -m ""]
    D --> E[Repositório Local]
    E --> F[git push]
    F --> G[GitHub (Remoto)]
```

---

## Comandos do Dia a Dia

### 1. Clonar um repositório remoto

Para começar a trabalhar, clone o repositório do GitHub para sua máquina:

```
git clone https://github.com/usuario/repositorio.git
```

### 2. Atualizar seu repositório local com o remoto

Antes de começar a trabalhar, atualize seu repositório local:

- **git pull**: Baixa e aplica as mudanças do GitHub no seu repositório local.
- **git fetch**: Apenas baixa as mudanças do GitHub, mas não aplica automaticamente. Use quando quiser ver o que mudou antes de atualizar.

```
git pull
```
ou
```
git fetch
```

### 3. Salvar mudanças locais

Após editar seus arquivos, siga estes passos:

1. **Adicionar arquivos para a área de preparação (staging):**
    ```
    git add .
    ```
2. **Salvar as mudanças no repositório local:**
    ```
    git commit -m "Mensagem explicando o que mudou"
    ```
3. **Enviar para o GitHub:**
    ```
    git push
    ```

### 4. Forçar o envio das mudanças locais para o repositório remoto (git push -f)

Em alguns casos, pode ser necessário forçar o envio das suas mudanças locais para o GitHub, ignorando o que está no repositório remoto. Isso acontece, por exemplo, quando há conflitos ou quando você reescreveu o histórico de commits localmente (como ao usar comandos como `git rebase` ou `git reset`)

Para forçar o envio e substituir o que está no remoto:

```
git push -f
```

**Atenção:** Esse comando apaga o histórico remoto e substitui pelo que está na sua máquina. Use apenas se tiver certeza de que não vai perder nada importante do repositório remoto. Pergunte ao seu professor se tiver dúvidas.

---

## Resumo do Fluxo Diário

1. **git pull** para atualizar seu código local.
2. Faça suas alterações.
3. **git add .** para preparar os arquivos.
4. **git commit -m ""** para salvar localmente.
5. **git push** para enviar ao GitHub.

---

Este guia é um ponto de partida para você salvar e atualizar seus projetos no GitHub durante as aulas e em casa.
