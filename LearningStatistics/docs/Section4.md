## 4-7
### (1)
$P(C) = P(C \cap (A \cup A^c))$  
$= P((C \cap A) \cup (C \cap A^c))$  
$= P(C \cap A) + P(C \cap A^c)$  
$= P(C) \cdot P(A \mid C) + P(C) \cdot P(A^c \mid C)$  
$\iff$ $P(A^c \mid C) = 1 - P(A \mid C)$  
$P(A \mid C)=0.95$ より、 $P(A^c \mid C) = 0.05$

$P(A \cap C) \cup P(A^c \cap C) \cup P(A \cap C^c) \cup P(A^c \cap C^c) = 1$  
$\iff$  $P(C) \cdot P(A \mid C) + P(C) \cdot P(A^c \mid C) + P(C^c) \cdot P(A \mid C^c) + P(C^c) \cdot P(A^c \mid C^c) = 1$  

$P(C)=0.005$  
$P(A^c \mid C^c)=0.95$ より、  
$P(A \mid C^c) = 0.05$  

ベイズの定理より、  
$P(C|A) = \cfrac{P(C) \cdot P(A \mid C)}{P(C) \cdot P(A \mid C) + P(C^c) \cdot P(A \mid C^c)}$  
$=0.087155...$
### (2)
$P(C) \cdot R + P(C) \cdot (1 - R) + P(C^c) \cdot P(A \mid C^c) + P(C^c) \cdot R= 1$   
$\iff$  $P(A \mid C^c) = \cfrac{1 - P(C) - R \cdot P(C^c)}{P(C^c)}$  
$P(C|A) \ge 0.9$  
$R \ge \cfrac{1791}{1792} = 0.999442...$




