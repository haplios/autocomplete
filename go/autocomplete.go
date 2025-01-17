package main

import (
	"net/http"
)

func main() {
	http.Handle("/", http.FileServer(http.Dir("./assets")))
	http.ListenAndServe(":3000", nil)
}

func handleRequest() {

}

type Node struct {
	Children    map[rune]Node
	IsEndOfWord bool
}

type Trie struct {
	Root Node
}

func TrieInsert(trie *Trie, word string) {
	var node = trie.Root

	for _, c := range word {
		if node.Children == nil {
			node.Children = make(map[rune]Node)
		}

		_, exists := node.Children[c]

		if !exists {
			node.Children[c] = Node{}
		}

		node = node.Children[c]
	}

	node.IsEndOfWord = true
}

func FindNode(prefix []rune, currentNode *Node) *Node {
	if len(prefix) == 0 {
		return currentNode
	}

	key := prefix[0]

	node, exists := currentNode.Children[key]

	if exists {
		return FindNode(prefix[1:], &node)
	} else {
		return nil
	}
}

func ListWords(currentNode *Node, word []rune, words []string) {
	if currentNode.IsEndOfWord {
		words = append(words, string(word))
	}

	for key, value := range currentNode.Children {

	}

}
