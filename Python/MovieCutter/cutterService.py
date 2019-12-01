# reference:
#https://github.com/manojmj92/subtitle-downloader/blob/master/subtitle-downloader/subtitle_downloader.py

import zipfile
import time
import sys
import shutil
import re
import os
import logging
import json
import hashlib
import glob
import requests
import urllib.request

PY_VERSION = sys.version_info[0]

LANGUAGE_CODES = {
    "Arabic": "ar",
    "Chinese": "zh",
    "Danish": "da",
    "Dutch": "nl",
    "English": "en",
    "Esperanto": "eo",
    "Finnish": "fi",
    "French": "fr",
    "German": "de",
    "Greek": "el",
    "Hebrew": "he",
    "Hindi": "hi",
    "Irish": "ga",
    "Italian": "it",
    "Japanese": "ja",
    "Korean": "ko",
    "Mongolian": "mn",
    "Norwegian": "no",
    "Persian": "fa",
    "Polish": "pl",
    "Portuguese": "pt",
    "Russian": "ru",
    "Spanish": "es",
    "Swedish": "sv",
    "Thai": "th",
    "Urdu": "ur",
    "Vietnamese": "vi",
    "Welsh": "cy",
    "Yiddish": "yi",
    "Zulu": "zu"
}

#this hash function receives the name of the file and returns the hash code
def get_hash(name):
    readsize = 64 * 1024
    with open(name, 'rb') as f:
        data = f.read(readsize)
        f.seek(-readsize, os.SEEK_END)
        data += f.read(readsize)
    return hashlib.md5(data).hexdigest()


def get_from_subdb(file_path, language, verbose=False):
    """Download subtitles from subdb."""
    try:
        # Skip this file if it is not a video
        root, extension = os.path.splitext(file_path)
        #if extension not in VIDEO_EXTENSIONS:
            #if verbose:
                #print(file_path + " is not a video file. Skipping.")
            #return
        
        language_code = LANGUAGE_CODES[language]
        filename = root + language_code + ".srt"
        
        if not os.path.exists(filename):
            headers = {'User-Agent': 'SubDB/1.0 (subtitle-downloader/1.0; http://github.com/manojmj92/subtitle-downloader)'}
            
            url = "http://api.thesubdb.com/?action=download&hash=" + get_hash(file_path) + "&language=" + language_code
            print(url)
            
            if PY_VERSION == 3:
                req = urllib.request.Request(url, None, headers)
                response = urllib.request.urlopen(req).read()
                print(reponse)

            if PY_VERSION == 2:

                req = urllib2.Request(url, '', headers)
                response = urllib2.urlopen(req).read()

            

            with open(filename, "wb") as subtitle:
                subtitle.write(response)
                if verbose:
                    print(language + " subtitles successfully downloaded for " + file_path)

    except:
        print(sys.exc_info()[0])
        print(language + " subtitles not found for " + file_path + " in subdb")