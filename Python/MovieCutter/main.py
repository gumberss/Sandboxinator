import moviepy.editor as mp

with open("MovieCutter/subtitle.srt") as f:
    content = f.read().splitlines()

i = 0

while i < len(content):
    


for index in range(len(content)):
    try:
        int(line)

    

clip = mp.VideoFileClip("MovieCutter/movie.mp3").subclip(0,1)
clip.audio.write_audiofile("MovieCutter/agregates/theaudio.mp3")


class Context:
    def __init__(self, sequence, startTime, endTime, sourceMessage, targetMessage):
        self.sequence = sequence
        self.startTime = startTime
        self.endTime = endTime
        self.sourceMessage = sourceMessage
        self.targetMessage = targetMessage