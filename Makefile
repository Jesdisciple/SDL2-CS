# Makefile for SDL2#
# Written by Ethan "flibitijibibo" Lee

# Source Lists
SRC = \
	SDL2-CS/src/LPUtf8StrMarshaler.cs \
	SDL2-CS/src/SDL2.cs \
	SDL2-CS/src/SDL2_image.cs \
	SDL2-CS/src/SDL2_mixer.cs \
	SDL2-CS/src/SDL2_ttf.cs

# Targets

debug: clean-debug
	mkdir -p SDL2-CS/bin/debug
	cp SDL2-CS/SDL2-CS.dll.config SDL2-CS/bin/debug
	dmcs /unsafe -debug -out:SDL2-CS/bin/debug/SDL2-CS.dll -target:library $(SRC)

clean-debug:
	rm -rf SDL2-CS/bin/debug

release: clean-release
	mkdir -p SDL2-CS/bin/release
	cp SDL2-CS.dll.config SDL2-CS/bin/release
	dmcs /unsafe -optimize -out:SDL2-CS/bin/release/SDL2-CS.dll -target:library $(SRC)

clean-release:
	rm -rf SDL2-CS/bin/release

clean: clean-debug clean-release
	rm -rf SDL2-CS/bin

all: debug release
