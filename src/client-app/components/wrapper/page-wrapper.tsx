const PageWrapper = ({children}: {children: React.ReactNode}) => {
    return (
        <>
          <main className="flex min-w-screen min-h-screen flex-col px-[16px] py-[24px] items-start">
            {children}
          </main>
        {/* <NavBar /> */}
        </>
    )
}

export default PageWrapper;