import { Box, CircularProgress } from "@mui/material";

const FullscreenLoader = () => {
    return (
      <Box
        sx={{
          position: 'fixed',
          top: 0,
          left: 0,
          width: '100vw',
          height: '100vh',
          backgroundColor: 'rgba(0, 0, 0, 0.5)', // Przyciemnione tło
          display: 'flex',
          alignItems: 'center',
          justifyContent: 'center',
          zIndex: 1300, // Wyższy z-index dla pokrycia wszystkich elementów
        }}
      >
        <CircularProgress color="primary" />
      </Box>
    );
  };
  
  export default FullscreenLoader;