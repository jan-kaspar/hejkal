import os
import re
import shutil

# configuration
inputDir = "."
songsDir = "Assets\Songs"
outputDir = ".."
    
# process all input files
songCollection = []

def CopyContents(source: str, dest):
    f_source = open(source, encoding="utf-8", errors="ignore")
    lines = f_source.readlines()
    f_source.close()

    dest.writelines(lines)

def InitSongFile(fileName: str, number: str, name: str, auth: str):
    f = open(fileName, "w", encoding="utf-8")

    CopyContents("songFileHeader.html", f)

    f.write("<h1>" + number + ": " + name + "</h1>\n")

    if auth:
        f.write("<h2>" + auth + "</h2>\n")

    return f

def FinaliseSongFile(file):
    if file == None:
        return
    
    CopyContents("songFileFooter.html", file)

    file.close()

def ProcessOneFile(fileName: str):
    f_in = open(fileName, "r", encoding="utf-8", errors="ignore")
    lines = f_in.readlines()

    f_out = None

    newSongPattern = re.compile("\\\\newsong{(.*)}")

    # process each line
    for line in lines:
        # remove whitespace
        line = line.strip()

        # skip comments
        if len(line) > 0 and line[0] == "#":
            continue

        # is it a newsong?
        sr = re.search(newSongPattern, line)
        if (sr):
            #print(sr.group(1))

            # parse line
            arguments = sr.group(1).split("|")
            number = arguments[0]
            name = arguments[1]
            auth = ""
            if len(arguments) > 2:
                auth = arguments[2]

            fn_out = number + ".html"

            #print("    {}, {}, {}, {}".format(number, name, auth, fn_out))

            # add to collection            
            songCollection.append((number, name, auth, fn_out))

            # close old file (if any)
            FinaliseSongFile(f_out)

            # open new file
            f_out = InitSongFile(os.path.join(outputDir, songsDir, fn_out), number, name, auth)

            continue

        # regular line
        if f_out != None:
            line = line.replace("{REF}", "<i>REF: </i>").replace("{ODP}", "<i>ODP: </i>")
            f_out.write(line + "<br>\n")

    FinaliseSongFile(f_out)

    f_in.close()

inputFiles = [f for f in os.listdir(inputDir) if (".txt" in f) and os.path.isfile(os.path.join(inputDir, f))]
for fileName in inputFiles:
    ProcessOneFile(os.path.join(inputDir, fileName))

# write search function
f_out = open(os.path.join(outputDir, "Search.gen.cs"), "w", encoding="utf-8")

CopyContents("searchFileHeader.cs", f_out)

for song in songCollection:
    number = song[0]
    name = song[1]
    auth = song[2]
    fn = song[3]
    #f_out.write("    if (strpos(\"{}\", $key) !== false || strpos(\"{}\", $key) !== false) echo \"<li><a href=\\\"{}\\\">{}: {}</a></li>\"\n".format(number, name, "songs/" + fn, number, name))
    f_out.write("\t\t\tallSongs.Add(new SongData(\"{}\", \"{}\"));\n".format(number, name))

CopyContents("searchFileFooter.cs", f_out)

# write asset block
#<ItemGroup><AndroidAsset Include="Assets\Songs\1.html" /></ItemGroup>