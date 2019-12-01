#import moviepy.editor as mp

#with open("MovieCutter/subtitle.srt") as f:
#    content = f.read().splitlines()


#for line in content:
#    print(line)

from fastapi import FastAPI
import cutterService

app = FastAPI()

@app.get("/")
def read_root():
    return {"Hello": "World"}


@app.get("/items/{item_id}")
def read_item(item_id: int, q: str = None):
    return cutterService.get_from_subdb(q, "English")




#clip = mp.VideoFileClip("MovieCutter/movie.mp3").subclip(0,1)
#clip.audio.write_audiofile("MovieCutter/agregates/theaudio.mp3")