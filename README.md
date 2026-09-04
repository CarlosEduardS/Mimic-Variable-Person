#  Mimic-Variable-Person (M.V.P)

[![License](https://img.shields.io/badge/license-Apache--2.0-blue.svg)](LICENSE)
[![Version](https://img.shields.io/badge/version-v0.2.1--beta-orange.svg)](#)
![Language](https://img.shields.io/badge/language-C%23_.NET-512BD4?logo=csharp&logoColor=white)

O **Mimic-Variable-Person (MVP)** é uma arquitetura de inteligência artificial modular inspirada na dinâmica de adaptação comportamental e cognitiva. O projeto é estruturado para simular processos neurais, emocionais e físicos de um agente autônomo.

---

##  Arquitetura do Projeto

O sistema é dividido em dois núcleos principais: **Cognição (Brain)** e **Atuação (Members)**.

```text
MimicAI/
├──  Brain/              # Módulos cognitivos e comportamentais
│   ├── Thought.cs         # Processamento de pensamentos e dados de entrada
│   ├── ThoughtData.json   # Base de dados de pensamentos
│   ├── Feelings.cs        # Estados emocionais e reatividade
│   └── FeelingsData.json  # Parâmetros de comportamento emocional
├──  Members/            # Módulos de atuadores e ações físicas/lógicas
│   ├── Arms.cs            # Controle de ações superiores/interações
│   ├── ArmsData.json      # Dados de calibração dos braços
│   ├── Legs.cs            # Controle de locomoção e posicionamento
│   └── LegsData.json      # Dados de movimentação
├──  GlobalFuncs.cs      # Utilitários globais e manipulação de datasets
└──  Program.cs          # Ponto de entrada e inicialização do sistema
```

## 📄 Licença

Este projeto está licenciado sob a **[Licença Apache 2.0](LICENSE)** — consulte o arquivo de licença para obter mais detalhes.
