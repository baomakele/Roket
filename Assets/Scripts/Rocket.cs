using UnityEngine;

/// <summary>
/// 火箭控制脚本 - 管理火箭的运动、加速和燃料消耗
/// </summary>
public class Rocket : MonoBehaviour
{
    [Header("运动参数")]
    [SerializeField] private float moveSpeed = 10f;           // 基础移动速度
    [SerializeField] private float boostAcceleration = 50f;   // 加速度
    [SerializeField] private float maxSpeed = 100f;           // 最大速度
    [SerializeField] private float lateralSpeed = 5f;         // 左右移动速度
    
    [Header("燃料参数")]
    [SerializeField] private float maxFuel = 100f;            // 最大燃料量
    [SerializeField] private float fuelConsumption = 10f;     // 每次加速消耗燃料
    [SerializeField] private float fuelRegenRate = 5f;        // 燃料恢复速率
    [SerializeField] private float boostDuration = 0.5f;      // 单次加速持续时间
    
    private float currentFuel;
    private float currentSpeed = 0f;
    private float boostTimer = 0f;
    private bool isAccelerating = false;
    private Rigidbody rocketRigidbody;
    
    // 事件
    public delegate void FuelChangedHandler(float fuel, float maxFuel);
    public event FuelChangedHandler OnFuelChanged;
    
    public delegate void SpeedChangedHandler(float speed);
    public event SpeedChangedHandler OnSpeedChanged;

    private void Start()
    {
        rocketRigidbody = GetComponent<Rigidbody>();
        if (rocketRigidbody == null)
        {
            rocketRigidbody = gameObject.AddComponent<Rigidbody>();
        }
        
        currentFuel = maxFuel;
        OnFuelChanged?.Invoke(currentFuel, maxFuel);
    }

    private void Update()
    {
        HandleInput();
        UpdateFuel();
        UpdateSpeed();
        UpdatePosition();
    }

    /// <summary>
    /// 处理玩家输入
    /// </summary>
    private void HandleInput()
    {
        // 加速输入
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AttemptBoost();
        }

        // 停止加速输入
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isAccelerating = false;
        }

        // 重新开始
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetRocket();
        }
    }

    /// <summary>
    /// 尝试进行加速
    /// </summary>
    private void AttemptBoost()
    {
        if (currentFuel >= fuelConsumption)
        {
            currentFuel -= fuelConsumption;
            isAccelerating = true;
            boostTimer = boostDuration;
            OnFuelChanged?.Invoke(currentFuel, maxFuel);
        }
    }

    /// <summary>
    /// 更新燃料状态
    /// </summary>
    private void UpdateFuel()
    {
        // 燃料恢复
        if (currentFuel < maxFuel)
        {
            currentFuel += fuelRegenRate * Time.deltaTime;
            currentFuel = Mathf.Min(currentFuel, maxFuel);
            OnFuelChanged?.Invoke(currentFuel, maxFuel);
        }

        // 更新加速状态
        if (isAccelerating)
        {
            boostTimer -= Time.deltaTime;
            if (boostTimer <= 0)
            {
                isAccelerating = false;
            }
        }
    }

    /// <summary>
    /// 更新火箭速度
    /// </summary>
    private void UpdateSpeed()
    {
        if (isAccelerating)
        {
            currentSpeed += boostAcceleration * Time.deltaTime;
        }
        else
        {
            // 逐渐减速
            currentSpeed = Mathf.Lerp(currentSpeed, moveSpeed, Time.deltaTime * 2f);
        }

        currentSpeed = Mathf.Clamp(currentSpeed, moveSpeed, maxSpeed);
        OnSpeedChanged?.Invoke(currentSpeed);
    }

    /// <summary>
    /// 更新火箭位置
    /// </summary>
    private void UpdatePosition()
    {
        // 向前移动
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

        // 左右移动
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * lateralSpeed * Time.deltaTime);

        // 限制位置范围
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -10f, 10f);
        transform.position = pos;
    }

    /// <summary>
    /// 重置火箭状态
    /// </summary>
    private void ResetRocket()
    {
        currentFuel = maxFuel;
        currentSpeed = 0f;
        isAccelerating = false;
        transform.position = Vector3.zero;
        OnFuelChanged?.Invoke(currentFuel, maxFuel);
        OnSpeedChanged?.Invoke(currentSpeed);
    }

    // Getter 方法
    public float GetCurrentFuel() => currentFuel;
    public float GetMaxFuel() => maxFuel;
    public float GetCurrentSpeed() => currentSpeed;
    public float GetMaxSpeed() => maxSpeed;
    public bool IsAccelerating() => isAccelerating;
}