import pysrt
import deepl

with open('settings.txt') as f:
   lines1 = f.read().splitlines()

API_KEY = lines1[1]
language = lines1[0]


with open('info.txt') as f:
    mylist = f.read().splitlines()

string_fragment = ""
orginal_file_path = mylist[0]
target_file_path = mylist[1]
translator = deepl.Translator(API_KEY)

def translate(text):
    cleaned_text = text.replace("\n", " () ")
    translated = str(translator.translate_text(cleaned_text, target_lang=language))
    translated = translated.replace(" () ","\n")
    translated = translated.replace(" (),","\n")
    translated = translated.replace(" ().","\n")
    return translated

def is_sentence_ending(character):
    sentence_endings = ['?', '!', '.']
    return character in sentence_endings

def split_sentence(text):
    splited_text = [""]
    splited_text[0] = text
    for char in text:
        if is_sentence_ending(char):
            splited_text = text.split(char)
            if len(splited_text[-1])==0:
                del splited_text[-1]
            splited_text[0] = splited_text[0] + char
    return splited_text

if orginal_file_path[-4:] != '.srt':
    raise ValueError("This is not srt file!")

subs = pysrt.open(orginal_file_path)
subs_len = len(subs)

for i in range(subs_len):
    text = subs[i].text
    splited_text = split_sentence(text)
    if len(string_fragment) == 0:
        if len(splited_text)>1:
            string_fragment = splited_text[-1] + " (^$^) "
            tmp = ""
            for index,x in enumerate(splited_text):
                if index == len(splited_text) - 1:
                    break
                tmp = tmp + x
            subs[i].text = translate(tmp)
        else:
            subs[i].text=translate(text)
    else:
        tmp_text = string_fragment + text
        tmp_text = translate(tmp_text)
        string_fragment = tmp_text.split(" (^$^) ")
        string_fragment[0] = string_fragment[0].lstrip()
        if len(string_fragment[0]) != 1 and i != 1:
            subs[i-1].text = subs[i-1].text + string_fragment[0]
        else:
            subs[i].text = string_fragment[0] + " " + string_fragment[1]
        string_fragment = ""
subs.save(target_file_path)



    
