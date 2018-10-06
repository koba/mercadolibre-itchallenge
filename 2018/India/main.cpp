#include <bits/stdc++.h>

using namespace std;

typedef long long int ll;
 
struct suffix
{
    ll index; 
    ll rank[2];
};

ll cmp(struct suffix a, struct suffix b)
{
    return (a.rank[0] == b.rank[0])?
           (a.rank[1] < b.rank[1] ?1: 0):
           (a.rank[0] < b.rank[0] ?1: 0);
}

vector<int> buildSuffixArray(string txt, ll n)
{
    struct suffix suffixes[n];

    for (ll i = 0; i < n; i++)
    {
        suffixes[i].index = i;
        suffixes[i].rank[0] = txt[i] - 'a';
        suffixes[i].rank[1] = ((i+1) < n) ? (txt[i + 1] - 'a') : -1;
    }

    sort(suffixes, suffixes+n, cmp);

    ll ind[n];
    
    for (ll k = 4; k < 2 * n; k *= 2)
    {
        ll rank = 0;
        ll prev_rank = suffixes[0].rank[0];
        suffixes[0].rank[0] = rank;
        ind[suffixes[0].index] = 0;
 
        for (ll i = 1; i < n; i++)
        {
            if (suffixes[i].rank[0] == prev_rank &&
               suffixes[i].rank[1] == suffixes[i-1].rank[1])
            {
                prev_rank = suffixes[i].rank[0];
                suffixes[i].rank[0] = rank;
            }
            else
            {
                prev_rank = suffixes[i].rank[0];
                suffixes[i].rank[0] = ++rank;
            }
            ind[suffixes[i].index] = i;
        }
 
        for (ll i = 0; i < n; i++)
        {
            ll nextindex = suffixes[i].index + k/2;
            suffixes[i].rank[1] = (nextindex < n) ? suffixes[ind[nextindex]].rank[0] : -1;
        }

        sort(suffixes, suffixes+n, cmp);
    }
    
    vector<int>suffixArr;
    for (ll i = 0; i < n; i++)
        suffixArr.push_back(suffixes[i].index);

    return  suffixArr;
}

vector<int> kasai(string txt, vector<int> suffixArr)
{
    ll n = suffixArr.size();

    vector<int> lcp(n, 0);

    vector<int> invSuff(n, 0);

    for (ll i=0; i < n; i++)
        invSuff[suffixArr[i]] = i;

    ll k = 0;

    for (ll i=0; i<n; i++)
    {
        if (invSuff[i] == n-1)
        {
            k = 0;
            continue;
        }

        ll j = suffixArr[invSuff[i]+1];

        while (i+k<n && j+k<n && txt[i+k]==txt[j+k])
            k++;
 
        lcp[invSuff[i]] = k;

        if (k>0)
            k--;
    }

    return lcp;
}

ll countDistinctSubstring(string txt)
{
    ll n = txt.length();
    
    vector<int> suffixArr = buildSuffixArray(txt, n);
    vector<int> lcp = kasai(txt, suffixArr);
    
    ll result = n - suffixArr[0];
 
    for (ll i = 1; i < lcp.size(); i++)
        result += (n - suffixArr[i]) - lcp[i - 1];

    return result;
}

int main()
{
    ifstream file("../_docs/India/Copia de input.txt");
    stringstream buffer;
    buffer << file.rdbuf();
    cout << countDistinctSubstring(buffer.str()) << endl;
    return 0;
}