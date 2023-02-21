import NextAuth from 'next-auth/next'
import GitHubProvider from 'next-auth/providers/github';
import AzureAd from 'next-auth/providers/azure-ad'

export default NextAuth({
    providers: [
      GitHubProvider({
        clientId: process.env.GITHUB_ID!,
        clientSecret: process.env.GITHUB_SECRET!,
      }),
      AzureAd({
        clientId: process.env.AZUREAD_ID!,
        clientSecret: process.env.AZUREAD_SECRET!,
      })
    ],
    theme: {
        colorScheme: "light",
      },
  });