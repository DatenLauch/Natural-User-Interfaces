using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ghost[] ghosts;
    public Player pacman;
    public Transform pellets;
    public int ghostMutiplier { get; private set; } = 1;
    public int score { get; private set; }
    public int lives { get; private set; }

    private void start() 
    {
        NewGame();
    }

    private void Update()
    {
        if(this.lives <= 0 && Input.anyKeyDown)
        {
            NewGame();
        }
    }

    private void NewGame() 
    {
        SetScore(0);
        SetLives(3);
        NewRound();
    }

    private void NewRound() 
    {
        foreach (Transform pellete in this.pellets)
        {
            pellete.gameObject.SetActive(true);
        }
        ResetState();
    }

    private void ResetState()
    {
        ResetGhostMultiplier();
        for(int i=0; i<ghosts.Length; i++)
        {
            this.ghosts[i].ResetState();
        }
        
        this.pacman.ResetState();
    }

    private void GameOver()
    {
        for(int i=0; i<ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(false);
        }
        
        this.pacman.gameObject.SetActive(false);
    } 

    private void SetScore(int score) 
    {
        this.score = score;
    }

    private void SetLives(int lives) 
    {
        this.lives = lives;
    }

    public void GhostEaten(Ghost ghost)
    {
        int ghostPoints = ghost.points * this.ghostMutiplier;
        SetScore(this.score + ghostPoints);
        this.ghostMutiplier++;
    }

    public void PacmanEaten()
    {
        this.pacman.gameObject.SetActive(false);
        SetLives(this.lives - 1);
        if(this.lives > 0)
        {
            Invoke(nameof(ResetState), 3.0f);
        } else {
            GameOver();
        }
    }

    public void PelletEaten(Pellet pellet)
    {
        // turning off the pellet
        pellet.gameObject.SetActive(false);
        // scoring the points
        SetScore(this.score + pellet.points);
        // checking whether all pellets are eaten
        if(!HasRemaingPellets()) 
        {
            this.pacman.gameObject.SetActive(false);
            Invoke(nameof(NewRound), 3.0f);
        }

    }
    private void ResetGhostMultiplier()
    {
        this.ghostMutiplier = 1;
    }

    public void PowerPelletEaten(PowerPellet pellet)
    {
        for(int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].frightened.Enable(pellet.duration);
        }

        PelletEaten(pellet);
        CancelInvoke();
        Invoke(nameof(ResetGhostMultiplier), pellet.duration);
    }

    private bool HasRemaingPellets()
    {
        foreach (Transform pellete in this.pellets)
        {
            if(pellete.gameObject.activeSelf)
            {
                return true;
            }
        }
        return false;
    }

    
}
