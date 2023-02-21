import React from 'react'
import { AppProps } from 'next/app'

import '../styles/index.css'
import { SessionProvider } from 'next-auth/react';
import { Session } from 'next-auth';



function MyApp({ Component, pageProps: { session, ...pageProps} }: AppProps<{ session: Session}>) {
  return (
    <SessionProvider session={session}>
  <Component {...pageProps} />
  </SessionProvider>
  )

}

export default MyApp;