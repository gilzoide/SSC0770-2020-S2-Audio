# Roteiro básico pra aula

## Setup
- Abrir Unity
- Abrir editor de código, caso precise mostrar alguma coisa
- Rotear som da Unity pro mic

## Atalhos (pra lembrar)
- "Espaço": play/pause de botões com música
- "D": segure para som de drone
- "B" ou "Mouse direito": berro

## Teoria
0. Cumprimentos, apresentação breve minha
  - Lembrar que isso tudo está no GitHub

1. Ondas sonoras
  - Sons são ondas mecânicas, oscilação do ar no nosso ouvido
  - Representação amplitude/energia x tempo
  - Existem outras representações, como energia/frequência
    + Citar Cálculo 4 e Fourrier

2. Representação digital do sinal
  - Nome bonito: PCM
  - Taxa de amostragem (Sample rate)
  - Quantização

3. Representação de múltiplos canais
  - Entrelaçados (interleaving)
  - Streaming

4. Formatos de arquivo
  - Decodificação em tempo de carregamento, inteiro vs streaming
  - Citar Multimídia

5. Áudio espacial
  - Listener vs Source
  - Simulações físicas como Doppler e oclusão

6. Filtros
  - Aplicação no Listener ou no Source

7. Mixer
  - Citar sistemas mais complexos de audio, como FMOD e Wwise 

## Prática na Unity
- Abrir CenaSemAudio e explicar o que vai rolar
- Duplicar CenaSemAudio pra CenaComAudio
- Importar arquivos de áudio
- Remover Listener da câmera
- Adicionar Listener no jogador
- Adicionar BGM
- Mostrar parâmetros do Source, como volume, 2D/3D, panning, pitch, PlayOnAwake, Loop
- Perguntar sobre UnityEvents, explicar se necessário
- Hook da UI de BGM com o Source
- Adicionar Sources aos pratos
- Hook do clique dos pratos com os Sources
- Criar Mixer
- Adicionar canais de BGM, SFX, mixar níveis de ganho
- Adicionar filtro Passa Baixa pra piscina + snapshot
- Hook da piscina
- Adicionar duck volume no grito
- Mostrar componentes de filtro, caso queiram usar

## Finalmentes
- Q&A
- Lembrar de novo que isso tudo está no GitHub
- vlw flws

- Commitar a CenaComAudio e mixer depois, pra quem quiser ver pronto
