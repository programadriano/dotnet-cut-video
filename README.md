# Descrição
A classe CutVideo é responsável por recortar um trecho específico de um arquivo de vídeo utilizando a ferramenta FFmpeg.

# Como usar
# Parâmetros
A função CutVideo recebe os seguintes parâmetros:

* inputFilePath (string): o caminho completo para o arquivo de vídeo que será recortado.
* outputFilePath (string): o caminho completo para o arquivo de vídeo que será gerado após o recorte.
* startTime (string): o tempo de início do trecho que será recortado, no formato "HH:mm:ss".
* duration (string): a duração do trecho que será recortado, no formato "HH:mm:ss".

# Exemplo de uso

Para utilizar a classe CutVideo, siga os seguintes passos:

* Instale o FFmpeg em sua máquina. Você pode baixá-lo através do site oficial: https://ffmpeg.org/download.html
* Adicione a classe CutVideo em seu projeto C#.
* Chame a função CutVideo passando os parâmetros desejados.

Segue um exemplo de uso:

```
var inputFilePath = "C:\\fiap\\video_exemplo\\video2.mp4";
var startTime = "00:00:30";
var duration = "00:00:10";
var nome = "video_cortado";
var outputFilePath = $"C:\\fiap\\video_exemplo\\{nome}.mp4";

CutVideo(inputFilePath, outputFilePath, startTime, duration);
```

Nesse exemplo, a função CutVideo irá recortar um trecho de 10 segundos do arquivo "C:\fiap\video_exemplo\video2.mp4", começando no tempo 00:00:30. O arquivo resultante será salvo em "C:\fiap\video_exemplo\video_cortado.mp4".

Caso deseje, você pode utilizar a função Console.ReadLine() para receber os valores de startTime, duration e nome por meio da entrada do usuário. Basta comentar as variáveis correspondentes e descomentar as linhas com a função Console.ReadLine().
