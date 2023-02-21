import React, { ReactNode } from 'react'
import Link from 'next/link'
import Head from 'next/head'
import Image from 'next/image'
import Logo from '../assets/images/logo_transparent_background.png'
import { signIn, signOut, useSession } from "next-auth/react";
import { useRouter } from 'next/router'


export default function Layout({children} : {children: ReactNode}) {
  const {data: session, status } = useSession()
  const router = useRouter()

  return (
<div>
    <Head>
      <title>Evently</title>
      <meta charSet="utf-8" />
      <meta name="viewport" content="initial-scale=1.0, width=device-width" />
    </Head>
    <header>
      <nav>
        <Image alt='Logo' src={Logo} width={100} height={100} />
        <Link className='menuitem' href="/">Events</Link>
        <Link className='menuitem' href="/settings">Settings</Link>
        
        { !session && (
        <Link className='authitem' onClick={(e) => { e.preventDefault(); signIn() } } href={''}>Login</Link>
        )
        }
        {
          session?.user && (<>
            <div className='profile-holder'>
              <Image src={session?.user.image} width={500} height={500} alt='avatar' className='profpic' onClick={(e) => router.push('/profile')}></Image>
              <Link className='authitem' onClick={(e) => { e.preventDefault(); signOut()}} href="">Sign out</Link>
            
            </div>
            </>
          )
        }
      </nav>
    </header>
    {children}
    <footer>
      <hr />
      <span>MXC Software</span>
    </footer>
  </div>
  )
}
