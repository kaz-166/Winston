# 5. 確率変数
## 5-1
### i)
> [0, 6]上の一様分布の密度関数、期待値、分散を求めよ。

密度関数は、

$$
f(x) = \begin{cases}
    1/6 & (0 \leq x \leq 6) \\
    0 & otherwise
  \end{cases}
$$

期待値は、
$$E(x) = \int_{-\infty}^{\infty}xf(x)dx$$
$$= \cfrac{1}{6}\int_{0}^{6}xdx$$
$$= 3$$
分散は、
$$V(x) = E(x^2) - (E(x))^2$$
$$= \int_{-\infty}^{\infty}x^2f(x)dx - (\int_{-\infty}^{\infty}xf(x)dx)^2$$
$$= \cfrac{1}{6}\int_{0}^{6}x^2dx - (\cfrac{1}{6}\int_{0}^{6}xdx)^2$$
$$= 18 - 3^2$$
$$= 9$$
**(答). 密度関数： $f(x)=1/6 (0 \leq x \leq 6), 0 (x < 0, x > 6)$ 、期待値：3、分散：9**
### ii)
> [0, 6]上の一様分布に関して、チェビシェフの不等式が成立することを示せ。

$$P(|X - \mu| \geq k\sigma) = 1 - \int_{\mu - k\sigma}^{\mu + k\sigma}f(x)dx$$

$\mu = 3$ 、 ${\sigma}^2 = 9$ なので、 $k > 1$ のとき、

$$1 - \int_{\mu - k\sigma}^{\mu + k\sigma}f(x)dx = 1 - \int_{0}^{1}f(x)dx = 0 \leq \cfrac{1}{k^2} \cdots (1)$$

 $k \leq 1$ のとき、

 $$1 - \int_{\mu - k\sigma}^{\mu + k\sigma}f(x)dx = 1 - \cfrac{1}{6}(3(1 + k) - 3(1 - k)) = 1 - k$$

 ここで、 $g(x) = x^3 - x^2 +1$ を考える。 $\cfrac{dg(x)}{dx} = x(3x -2)$ なので、 $0 \leq x \leq 1$ において
 
 $$g(x) \geq g(\cfrac{2}{3}) = \cfrac{23}{27} \ge 0$$
 
 よって、

 $$\cfrac{1}{k^2} - (1 - k) = \cfrac{1}{k^2}g(k) \ge 0$$

 $$\iff 1 - k = 1 - \int_{\mu - k\sigma}^{\mu + k\sigma}f(x)dx \leq \cfrac{1}{k^2} \cdots (2)$$

 (1)、(2)より、すべての $k$ について

 $$P(|X - \mu| \geq k\sigma) \leq \cfrac{1}{k^2}$$

 が成立する。よってチェビシェフの不等式が成り立つことが示された。(証終)


### iii)
> [0, 1]上の一様分布に関して、歪度および突度を求めよ。

歪度は、

$$\cfrac{E((x - \mu)^3)}{\sigma^3} = \cfrac{1}{\sigma^3}(E(x^3) -3 \mu E(x^2) + 3 {\mu}^3 - \mu^3)$$

$$ 　　　　　　= \cfrac{1}{\sigma^3}(\int_{-\infty}^{\infty}x^3 f(x)dx -3 (\int_{-\infty}^{\infty}x f(x)dx) (\int_{-\infty}^{\infty}x^2 f(x)dx) + 2 (\int_{-\infty}^{\infty}x f(x)dx)^3)$$

$$ 　　= \cfrac{1}{\sigma^3}(\int_{0}^{1}x^3 dx -3 (\int_{0}^{1}x dx) (\int_{0}^{1}x^2 dx) + 2 (\int_{0}^{1}x dx)^3)$$

$$=0$$

突度は、

$$\alpha_4 = \cfrac{E((x - \mu)^4)}{\sigma^4} = \cfrac{1}{\sigma^4}(E(x^4) + 4 {\mu}^2 E(x^2) + {\mu}^4 - 4 \mu E(x^3) - 4 {\mu}^3 E(x) + 2 {\mu}^2 E(x^2))$$

$$ 　　　　= \cfrac{1}{\sigma^4}(\int_{0}^{1}x^4 dx + 6 (\int_{0}^{1}x dx)^2 \int_{0}^{1}x^2 dx - 4 (\int_{0}^{1}x dx) (\int_{0}^{1}x^3 dx) - 3 (\int_{0}^{1}x dx)^4)$$

$$= \cfrac{1}{80{\sigma}^2}$$

ここで、 ${\sigma} = \cfrac{1}{12}$ より、 $\alpha_4 = \cfrac{9}{5}$　。よって、 $\beta_4 = \alpha_4 - 3 = -\cfrac{6}{5}$

**(答). 歪度： $0$、突度： $-\cfrac{6}{5}$**

## 5-2
> 5.2節の宝くじの期待値を求めよ。

**(答). 89.4076...**

(注記) 計算に使用したコードは下記
https://github.com/kaz-166/LearningStatistics/blob/2a1aba2cf17e57e1ea5c34679c2680e1e9d4f7ce/LearningStatistics/calcs/Answer.cs#L19-L28
## 5-3 聖ペテルスブルグの逆説
> コインを繰り返し投げ、初めて表が出たときに止める。それが $n$ 回目であるとき、 $2^n$ 円を得るものとする。このとき、
> 
> i) 得られる額 $X$ の確率分布を求めよ
> 
> ii) $E(X)$ は存在しない(無限大に発散する)ことを示せ。

### i)
$n$ 回目で初めて表が出る確率は $\cfrac{1}{2^n}$ なので、得られる金額 $X$ の確率分布は

$$P(X = 2^n) = \cfrac{1}{2^n}$$

で表される。

### ii)
$$E(X) = \lim_{n\to \infty}\sum_{k = 1}^{n}\cfrac{1}{2^k} \cdot 2^k$$

$$= \lim_{n\to \infty}\sum_{k = 1}^{n}1$$

$$= 1 + 1 + 1 + \cdots$$

よって $E(X)$ は正の無限大に発散するため、存在しない。(証終)
## 5-4 最小平均二乗
> $E(X-a)^2$ を最小にする $a$ およびその最小値を求めよ。

$$E(X-a)^2 = E(X^2) - 2E(a)E(X) + (E(a))^2$$

$$= E(X^2) - 2aE(X) + a^2$$

$$= (a - E(X))^2$$

よって、 $a = E(X)$ の時に最小値0をとる。

**(答). $a = E(X)$ 、 最小値0**

## 5-5 
> 正 $n$ 面体で1, 2, ...,nの乱数を発生させるとする。このときの期待値と分散を求めよ。

期待値は、
$$E(X) = \sum_{k = 1}^{n}\cfrac{k}{n}$$

$$= \cfrac{n + 1}{2}$$

分散は、
$$V(X) = E(X^2) - (E(X))^2$$

$$= \sum_{k = 1}^{n}\cfrac{k^2}{n} - (\sum_{k = 1}^{n}\cfrac{k}{n})^2$$

$$= \cfrac{(n + 1)(2n + 1)}{6} - (\cfrac{n + 1}{2})^2$$

$$= \cfrac{n^2 - 1}{12}$$

**(答). 期待値： $\cfrac{n + 1}{2}$ 分散： $\cfrac{n^2 - 1}{12}$**

## 5-6 一様分布の平方変換
> 確率変数 $X$ が[0, 1]上の一様分布に従うとき、 $X^2$ の累積分布関数、密度関数、期待値、分散を求めよ。

累積分布関数は、

$$F_{X^2}(x) = P(X^2 \leq x) = \int_{-\infty}^{\sqrt{x}}f(x)dx = \int_{0}^{\sqrt{x}}dx = \sqrt{x}$$

$$F_{X^2}(x) = 0　　　　　(x \le 0)$$

$$F_{X^2}(x) = \sqrt{x}　(0 \leq x \leq 1)$$

$$F_{X^2}(x) = 1　　　　　(x \ge 1)$$

確率密度関数は、

$$f_{X^2}(x) = \frac{d}{dx}F_{X^2}(x) = \cfrac{d}{dx}\int_{-\infty}^{\sqrt{x}}f(x)dx = \cfrac{1}{2\sqrt{x}}$$

期待値は

$$E(X^2) = \int_{0}^{1}x^2f(x) = \cfrac{1}{3}$$

分散は

$$V(X^2) = E((X^2 - \mu)^2) = E(X^4) - (E(X^2))^2$$

$$= \int_{0}^{1}x^4dx - (\int_{0}^{1}x^2dx)^2 = \cfrac{4}{45}$$

## 5-7 正規分布の平方変換
> 確率変数 $X$ が[0, 1]上の正規分布に従うとき、 $X^2$ の累積分布関数、密度関数、期待値、分散を求めよ。

$$f(x) = N(1, 0) = \cfrac{1}{\sqrt{2\pi}}e^{-\cfrac{x^2}{2}}$$

$$F_{X^2}(x) = P(X^2 \leq x) = \cfrac{1}{\sqrt{2\pi}}\int_{-\sqrt{x}}^{\sqrt{x}}e^{-\cfrac{t^2}{2}}dt$$

$$= \cfrac{2}{\sqrt{2\pi}}(\int_{0}^{\sqrt{x}}t^{2}e^{-\cfrac{t^2}{2}})$$

$$= \cfrac{2}{\sqrt{2\pi}}(\int_{-\infty}^{\sqrt{x}}e^{-\cfrac{t^2}{2}}dt - \int_{-\infty}^{0}e^{-\cfrac{t^2}{2}}dt)$$

[0, 1]の正規分布の累積分布関数を $\varPhi(x)$ とすると、 $F_{X^2}(x) = 2(\varPhi(\sqrt{x}) - \cfrac{1}{2})$ と表せる。

密度関数は、

$$f_{X^2}(x) = \cfrac{d}{dx}F_{X^2}(x) = 2\cfrac{d}{dx}\int_{0}^{\sqrt{x}}e^{\cfrac{t^2}{2}}dt$$

ここで、 $\cfrac{d}{dx}\int_{0}^{\sqrt{x}}e^{\cfrac{t^2}{2}}dt$ の原始関数を $G(x)$ とおくと、

$$\cfrac{d}{dx}\int_{0}^{\sqrt{x}}e^{\cfrac{t^2}{2}}dt = G(\sqrt{x}) - G(0)$$

$$2\cfrac{d}{dx}\int_{0}^{\sqrt{x}}e^{\cfrac{t^2}{2}}dt = 2e^{-\cfrac{x^2}{2}}\cfrac{d(\sqrt{x})}{dx}$$

$$= \cfrac{1}{\sqrt{2 \pi x}} e^{-\cfrac{x^2}{2}}$$

期待値は、

$$E(X^2) = \cfrac{1}{\sqrt{2\pi}}\int_{-\infty}^{\infty}x^2e^{-\cfrac{x^2}{2}}dx$$

$$= -\cfrac{1}{\sqrt{2\pi}}\int_{-\infty}^{\infty}x\cfrac{d}{dx}e^{-\cfrac{x^2}{2}}dx$$

$$= \cfrac{1}{\sqrt{2\pi}}\int_{-\infty}^{\infty}e^{-\cfrac{x^2}{2}}dx$$

$$= 1$$

分散は、

$$X(X^2) = E(X^4) - (E(X^2))^2$$ 

ここで、

$$E(X^4) = \cfrac{1}{\sqrt{2\pi}}\int_{-\infty}^{\infty}x^4e^{-\cfrac{x^2}{2}}dx$$

$$= -\cfrac{1}{\sqrt{2\pi}}\int_{-\infty}^{\infty}x^3\cfrac{d}{dx}e^{-\cfrac{x^2}{2}}dx$$

$$= \cfrac{3}{\sqrt{2\pi}}\int_{-\infty}^{\infty}x^2e^{-\cfrac{x^2}{2}}dx$$

$$= 3$$

よって、

$$V(Y^2) = 2$$
