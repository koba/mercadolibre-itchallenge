# -*- encoding: utf-8 -*-

if __name__ == "__main__":
        # Computing our magic number...
        # I wonder why it is taking so long!

        max_limit = 12345678987654320

        linear_sum = max_limit * (max_limit + 1) / 2

        max_limit /= 5
        squared_sum = max_limit * (max_limit + 1) * (max_limit * 2 + 1) / 6

        max_limit = max_limit * 5 * 20
        cubic_sum = max_limit * max_limit * (max_limit + 1) * (max_limit + 1) * 2

        print(linear_sum + squared_sum + cubic_sum)